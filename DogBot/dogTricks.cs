﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using ALIVE;
/*using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Speech.Recognition.SrgsGrammar;*/
using System.Collections.ObjectModel;
//using SimpleGrammar;

using Kaldi;


namespace DogsBrain
{
    public static class dogTricks
    {

        public static void obeyText(DogsMind myMind, string sentence)
        {
                if (sentence == null || sentence == "")
                {
                    Console.WriteLine("obeyText: sentence empty");
              //      myMind.mySynth.SpeakAsync("Sorry, master, I didn't get this command");
                    return;
                }


            /*    ParseTree pt = new ParseTree(myMind.ParseMachine, sentence);
                if (pt == null || pt.root == null)
                {
                    myMind.oboxSay("Parse failed");
                    Console.WriteLine("Parse of failed");
                    return;
                }
                pt.root.merge_W_leaves();
                Console.WriteLine("Parse result: " + pt.root.toSexp());*/
                CD commandCD = new CD(sentence);
                Console.WriteLine("Command: " + commandCD.ToSexp());
                concept comCon = commandCD.head;
                string cmd = comCon.concept_name;



                if (dogTask.tasks.Contains(cmd)) //If we got a known command, create a new dog task
                {
                    //Save the command arguments in the fields of the new dog task and invoke the command method
                    dogTask dt = new dogTask(myMind, cmd);
                    dt.taskArgs = commandCD;
                    myMind.myContext.last_command = commandCD;
                    float x, y;
                    myMind.myDog.Coordinates(out x, out y);
                    myMind.myContext .start_pos_x = x;
                    myMind.myContext.start_pos_y = y;
                    myMind.myContext.start_angle = myMind.myDog.Orientation();
                    Type myType = dt.GetType();
                    MethodInfo myInfo = myType.GetMethod(cmd);
                    myInfo.Invoke(dt, null);
                //    myMind.mySynth.SpeakAsync("Done, master!");
                }
                /*else
                {
                    Console.WriteLine("Unknown command: " + cmd);
                    myMind.mySynth.SpeakAsync("Sorry, master, I don't know this command");
                }*/
        }


//        public static void obeyCMD(DogsMind myMind, ParseTreeRuleNode pn)
//        {
//            /*if (sentence == null || sentence == "")
//            {
//                Console.WriteLine("obeyText: sentence empty");
//                //      myMind.mySynth.SpeakAsync("Sorry, master, I didn't get this command");
//                return;
//            }*/
//
//
//                ParseTree pt = new ParseTree(myMind.ParseMachine, sentence);
//                if (pt == null || pt.root == null)
//                {
//                    myMind.oboxSay("Parse failed");
//                    Console.WriteLine("Parse of failed");
//                    return;
//                }
//                pt.root.merge_W_leaves();
//                Console.WriteLine("Parse result: " + pt.root.toSexp());
//            CD commandCD = new CD(pn);
//            Console.WriteLine("Command: " + commandCD.ToSexp());
//            concept comCon = commandCD.head;
//            string cmd = comCon.concept_name;
//
//
//
//            if (dogTask.tasks.Contains(cmd)) //If we got a known command, create a new dog task
//            {
//                //Save the command arguments in the fields of the new dog task and invoke the command method
//                dogTask dt = new dogTask(myMind, cmd);
//                dt.taskArgs = commandCD;
//                myMind.myContext.last_command = commandCD;
//                float x, y;
//                myMind.myDog.Coordinates(out x, out y);
//                myMind.myContext.start_pos_x = x;
//                myMind.myContext.start_pos_y = y;
//                myMind.myContext.start_angle = myMind.myDog.Orientation();
//                Type myType = dt.GetType();
//                MethodInfo myInfo = myType.GetMethod(cmd);
//                myInfo.Invoke(dt, null);
//                //    myMind.mySynth.SpeakAsync("Done, master!");
//            }
//            /*else
//            {
//                Console.WriteLine("Unknown command: " + cmd);
//                myMind.mySynth.SpeakAsync("Sorry, master, I don't know this command");
//            }*/
//        }
	


        //This is the old code to obey text commands through the chat box
        public static void obeyMaster(DogsMind dm)
        {
            /*ALIVE.SmartDog myDog = dm.myDog;
            string msg = "";
            dogTask dt;
            myDog.SayMessage("I am ready");
            msg = myDog.GetMessage();
            if (msg == null || msg == "") msg = myDog.GetMessage();
            if (msg == null || msg == "")
            {
                myDog.SayMessage("Wooff, wooff!");
                return;
            }
            int ind = msg.IndexOf(":");
            string cmd = msg.Substring(ind + 2);
            int length = cmd.Length;
            cmd = cmd.Substring(0, length - 2);
            if (dogTask.tasks.Contains(cmd))
            {
                dt = new dogTask(dm, cmd);
                Type myType = dt.GetType();
                MethodInfo myInfo = myType.GetMethod(cmd);
                myInfo.Invoke(dt, null);
                myDog.SayMessage("Done, master!");
                return;
            }
            myDog.SayMessage("Wooff, wooff!");*/
        }

        //=============================================================================================
        //Various dog tricks start here

        public static bool walk_to_point(DogsMind myMind, AliveObject target)
        {
            for (int i = 0; i < 25; i++)
            {
                if (walkTo(myMind, target) == true) return true;
                myMind.update_explored(); //If not at target, look around and try again
            }
            return false;
        }

        //This method creates a Dijkstra path to the target and tries to follow it until it hits an unexplored grid point
        public static bool walkTo(DogsMind myMind, AliveObject target)
        {
            float xc, yc, dist;
            myMind.myDog.Coordinates(out xc, out yc);
            dist = distance(xc, yc, target.X, target.Y);
            Console.WriteLine("Walking from <" + xc.ToString() + "," + yc.ToString() + "> to <" + target.name + "> at <" + target.X.ToString() + "," + target.Y.ToString() + ">");
            if (dist < 1) return true;
            walkPath wpath = new walkPath(xc, yc, target, myMind); //this creates the dijkstra path
            Console.WriteLine("Path = " + wpath.ToMessage(wpath.path));
            if (wpath.path.Count == 0) return false;
            return wpath.followPath(); //this follows the path either to the end or to the first unexplored grid point
        }

        //Same as above, but walks to a point, instead of a target object
        public static bool walkTo(DogsMind myMind, float xt, float yt)
        {
            float xc, yc, dist;
            myMind.myDog.Coordinates(out xc, out yc);
            dist = distance(xc, yc, xt, yt);
            Console.WriteLine("Walking from <" + xc.ToString() + "," + yc.ToString() + "> to <" + xt.ToString() + "," + yt.ToString() + ">");
            if (dist < 1) return true;
            walkPath wpath = new walkPath(xc, yc, xt, yt, myMind);
            Console.WriteLine("Path = " + wpath.ToMessage(wpath.path));
            if (wpath.path.Count == 0) return false;
            return wpath.followPath();
        }

        //walk to a point but stop after 10 steps
        public static bool walkTo(DogsMind myMind, float xt, float yt, int lim)
        {
            float xc, yc, dist;
            myMind.myDog.Coordinates(out xc, out yc);
            dist = distance(xc, yc, xt, yt);
            Console.WriteLine("Walking from <" + xc.ToString() + "," + yc.ToString() + "> to <" + xt.ToString() + "," + yt.ToString() + ">");
            if (dist < 1) return true;
            walkPath wpath = new walkPath(xc, yc, xt, yt, myMind);
            Console.WriteLine("Path = " + wpath.ToMessage(wpath.path));
            if (wpath.path.Count == 0) return false;
            return wpath.followPath(lim);
        }

        //Tries reaching the point up to 25 times
        public static bool walk_to_point(DogsMind myMind, float x, float y)
        {
            for (int i = 0; i < 25; i++)
            {
                if (walkTo(myMind, x, y) == true) return true;
                myMind.update_explored();
            }
            return false;
        }

        public static float distance(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        //======================================================================================
        //Matches an object to a conceptual description
        public static float matchObj(AliveObject obj, CD descr, DogsMind myMind)
        {
            string fam = obj.family.ToLower();
            concept obj_concept = (concept)concept.all_concepts[fam];
            if (obj_concept == null) return 0;
            concept descr_concept = descr.head;
            if (descr_concept == null) return 0;
            if (obj_concept.test_isa(descr_concept) == false) return 0;
            float res = 1.0F;
            Console.WriteLine("Matching " + obj.name + " to " + descr.ToSexp());
            foreach (DictionaryEntry i in descr.PropList) // check color and size first
            {
                string prop = (string)i.Key;
                switch (prop)
                {
                    case "color":
                        res = res * matchColor(obj, (string)i.Value, myMind);
                        break;
                    case "size":
                        res = res * matchSize(obj, (string)i.Value, myMind);
                        break;
                    default:
                        break;
                }
                if (res < .1) break;
            }
            if (res >= .1)
            {
                foreach (DictionaryEntry i in descr.PropList)
                {
                    string prop = (string)i.Key;
                    switch (prop)
                    {
                        case "near":
                            res = res * matchNear(obj, (CD)i.Value, myMind);
                            break;
                        case "behind":
                            res = res * matchBehind(obj, (CD)i.Value, myMind);
                            break;
                        case "front":
                            res = res * matchInFrontOf(obj, (CD)i.Value, myMind);
                            break;
                        case "left":
                            res = res * matchToTheLeftOf(obj, (CD)i.Value, myMind);
                            break;
                        case "right":
                            res = res * matchToTheRightOf(obj, (CD)i.Value, myMind);
                            break;
                        case "north":
                            res = res * matchToTheDirOf(obj, (CD)i.Value, "north", myMind);
                            break;
                        case "south":
                            res = res * matchToTheDirOf(obj, (CD)i.Value, "south", myMind);
                            break;
                        case "east":
                            res = res * matchToTheDirOf(obj, (CD)i.Value, "east", myMind);
                            break;
                        case "west":
                            res = res * matchToTheDirOf(obj, (CD)i.Value, "west", myMind);
                            break;
                        default:
                            break;
                    }
                    if (res < .1) break;
                }
            }
            Console.WriteLine("Result of matching " + obj.name + " to " + descr.ToSexp() + " is " + res.ToString());
            return res;
        }

        //Colors are matched literally
        private static float matchColor(AliveObject obj, string d, DogsMind myMind)
        {
            float res = 1F;
            if (d != obj.color) res = 0;
            Console.WriteLine("Matching color of " + obj.name + " to " + d + " Result: " + res.ToString());
            return res;
        }

        //Sizes are matched based on the average height of the object family
        //We may want to start with a default average height, but then re-calculate it after we've seen a few objects
        private static float matchSize(AliveObject obj, string d, DogsMind myMind)
        {
            float res = 0;
            float obj_height = obj.height;
            string fam = obj.family.ToLower();
            concept obj_concept = (concept)concept.all_concepts[fam];
            object h = obj_concept.properties["average_height"];
            float avg_height = (float)h;
            switch (d)
            {
                case "small":
                    if (obj_height <= .5 * avg_height) { res = 1.0F; break; }
                    if (obj_height > 1.5 * avg_height) { res = 0; break; }
                    res = 1.5F - obj_height / avg_height;
                    break;
                case "big":
                case "tall":
                    if (obj_height >= 1.5 * avg_height) { res = 1.0F; break; }
                    if (obj_height < .5 * avg_height) { res = 0; break; }
                    res = obj_height / avg_height - .5F;
                    break;
                default:
                    break;
            }
            if (d == "small")
                Console.WriteLine("Matching size of " + obj.name + " to " + d + " Result " + res.ToString());
            return res;
        }

        //We draw ellipses around the base shape and stretch "nearness" with the height of the object
        //5 meters is "nearer" to a tall tree than to a short tree
        private static float matchNear(AliveObject obj, CD descr, DogsMind myMind)
        {
            Console.WriteLine("Matching near");
            concept descr_concept = descr.head;
            if (descr_concept == null) return 0;
            if (descr_concept.concept_name == "you") return matchNearYou(obj, myMind);
            float best = 0;
            foreach (DictionaryEntry i in myMind.knownObjects)
            {
                string fam = (string)i.Key;
                concept obj_concept = (concept)concept.all_concepts[fam];
                if (obj_concept.test_isa(descr_concept) == true)
                {
                    Hashtable knownFamObjects = (Hashtable)i.Value;
                    foreach (DictionaryEntry j in knownFamObjects)
                    {
                        AliveObject obj2 = (AliveObject)j.Value;
                        float zz = matchObj(obj2, descr, myMind);
                        float w = Math.Max(obj2.width, 1);
                        float d = Math.Max(obj2.depth, 1);
                        float h = Math.Max(obj2.height, 1);
                        float x_diff = obj2.X - obj.X;
                        float y_diff = obj2.Y - obj.Y;
                        float dist = (float)Math.Sqrt((x_diff * x_diff) / (w * w) + (y_diff * y_diff) / (d * d)) / h;
                        float ww;
                        if (dist < 3F)
                        {
                            ww = 1.0F;
                        }
                        else
                        {
                            if (dist > 7F)
                            {
                                ww = 0;
                            }
                            else
                            {
                                ww = (7F - dist) / 4F;
                            }
                        }
                        zz = zz * ww;
                        Console.WriteLine("Near degree = " + ww.ToString());
                        if (zz > best) best = zz;
                    }
                }
            }
            Console.WriteLine("Best conf for near: " + best.ToString());
            return best;
        }

        private static float matchNearYou(AliveObject obj, DogsMind myMind)
        {
            float x_diff = myMind.myContext.start_pos_x - obj.X;
            float y_diff = myMind.myContext.start_pos_y - obj.Y;
            float dist = (float)Math.Sqrt((x_diff * x_diff) + (y_diff * y_diff));
            float ww;
            if (dist < 3F)
            {
                ww = 1.0F;
            }
            else
            {
                if (dist > 7F)
                {
                    ww = 0;
                }
                else
                {
                    ww = (7F - dist) / 4F;
                }
            }
            Console.WriteLine("Near degree = " + ww.ToString());
            return ww;
        }

        //The degree of "behindness" is computed from the point of view of the dog at the start of the task
        //We test the "behindness" of obj with respect to all known objects matching descr and return the highest degree
        private static float matchBehind(AliveObject obj, CD descr, DogsMind myMind)
        {
            float dog_x, dog_y, obj_x, obj_y;
            Console.WriteLine("Matching behind");
            concept descr_concept = descr.head;
            if (descr_concept == null) return 0;
            if (descr_concept.concept_name == "you") return matchBehindYou(obj, myMind);
            float best = 0;
            foreach (DictionaryEntry i in myMind.knownObjects)
            {
                string fam = (string)i.Key;
                concept obj_concept = (concept)concept.all_concepts[fam];
                if (obj_concept.test_isa(descr_concept) == true)
                {
                    Hashtable knownFamObjects = (Hashtable)i.Value;
                    foreach (DictionaryEntry j in knownFamObjects)
                    {
                        AliveObject obj2 = (AliveObject)j.Value;
                        float zz = matchObj(obj2, descr, myMind);
                        //transform the coordinates of the dog at the beginning of the task and of obj relative to the center of obj2
                        change_origin(obj2.X, obj2.Y, obj2.angle, myMind.myContext.start_pos_x, myMind.myContext.start_pos_y, out dog_x, out dog_y);
                        change_origin(obj2.X, obj2.Y, obj2.angle, obj.X, obj.Y, out obj_x, out obj_y);
                        float w = Math.Max(obj2.width, 1);
                        float d = Math.Max(obj2.depth, 1);
                        float h = Math.Max(obj2.height, 1);
                        bool not_behind = (dog_x < 0 && obj_x < -w || dog_x >= 0 && obj_x > w || dog_y < 0 && obj_y < -d || dog_y >= 0 && obj_y > d);
                        Console.WriteLine("not_behind = " + not_behind.ToString());
                        if (not_behind == false)
                        {
                            //This is ellipsoidal distance with units proportional to the size of the reference object
                            float dist = (float)Math.Sqrt(obj_x * obj_x / w * w + obj_y * obj_y / d * d) / h;
                            float ww;
                            if (dist < 10F)
                            {
                                ww = 1.0F;
                            }
                            else
                            {
                                if (dist > 30F)
                                {
                                    ww = 0;
                                }
                                else
                                {
                                    ww = 1.5F - dist / 20.0F;
                                }
                            }
                            zz = zz * ww;
                            Console.WriteLine("Behind dist = " + dist.ToString() + " degree = " + ww.ToString());
                            if (zz > best) best = zz;
                        }
                    }
                }
            }
            Console.WriteLine("Best conf for behind: " + best.ToString());
            return best;
        }

        private static float matchBehindYou(AliveObject obj, DogsMind myMind)
        {
            float obj_x, obj_y;
            change_origin(myMind.myContext.start_pos_x, myMind.myContext.start_pos_y, myMind.myContext.start_angle, obj.X, obj.Y, out obj_x, out obj_y);
            bool not_behind = (obj_y > 0);
            Console.WriteLine("not_behind = " + not_behind.ToString());
            float ww = 0;
            if (not_behind == false)
            {
                float dist = (float)Math.Sqrt(obj_x * obj_x + obj_y * obj_y);
                if (dist < 10F)
                {
                    ww = 1.0F;
                }
                else
                {
                    if (dist > 30F)
                    {
                        ww = 0;
                    }
                    else
                    {
                        ww = 1.5F - dist / 20.0F;
                    }
                }
                Console.WriteLine("Behind dist = " + dist.ToString() + " degree = " + ww.ToString());
            }
            return ww;
        }

        private static float matchInFrontOf(AliveObject obj, CD descr, DogsMind myMind)
        {
            float dog_x, dog_y, obj_x, obj_y;
            Console.WriteLine("Matching in front of");
            concept descr_concept = descr.head;
            if (descr_concept == null) return 0;
            if (descr_concept.concept_name == "you") return matchInFrontOfYou(obj, myMind);
            float best = 0;
            foreach (DictionaryEntry i in myMind.knownObjects)
            {
                string fam = (string)i.Key;
                concept obj_concept = (concept)concept.all_concepts[fam];
                if (obj_concept.test_isa(descr_concept) == true)
                {
                    Hashtable knownFamObjects = (Hashtable)i.Value;
                    foreach (DictionaryEntry j in knownFamObjects)
                    {
                        AliveObject obj2 = (AliveObject)j.Value;
                        float zz = matchObj(obj2, descr, myMind);
                        //transform the coordinates of the dog at the beginning of the task and of obj relative to the center of obj2
                        change_origin(obj2.X, obj2.Y, obj2.angle, myMind.myContext.start_pos_x, myMind.myContext.start_pos_y, out dog_x, out dog_y);
                        change_origin(obj2.X, obj2.Y, obj2.angle, obj.X, obj.Y, out obj_x, out obj_y);
                        float w = Math.Max(obj2.width, 1);
                        float d = Math.Max(obj2.depth, 1);
                        bool not_in_front_of = (dog_x < 0 && obj_x > w || dog_x >= 0 && obj_x < -w || dog_y < 0 && obj_y > d || dog_y >= 0 && obj_y < -d);
                        Console.WriteLine("not_in_front_of = " + not_in_front_of.ToString());
                        if (not_in_front_of == false)
                        {
                            float dist = (float)Math.Sqrt(obj_x * obj_x / w * w + obj_y * obj_y / d * d);
                            float ww;
                            if (dist < 10F)
                            {
                                ww = 1.0F;
                            }
                            else
                            {
                                if (dist > 30F)
                                {
                                    ww = 0;
                                }
                                else
                                {
                                    ww = 1.5F - dist / 20.0F;
                                }
                            }
                            zz = zz * ww;
                            Console.WriteLine("In front of degree is " + ww.ToString());
                            if (zz > best) best = zz;
                        }
                    }
                }
            }
            Console.WriteLine("Best conf for in front of: " + best.ToString());
            return best;
        }

        private static float matchInFrontOfYou(AliveObject obj, DogsMind myMind)
        {
            float obj_x, obj_y;
            change_origin(myMind.myContext.start_pos_x, myMind.myContext.start_pos_y, myMind.myContext.start_angle, obj.X, obj.Y, out obj_x, out obj_y);
            bool behind = (obj_y < 0);
            Console.WriteLine("behind = " + behind.ToString());
            float ww = 0;
            if (behind == false)
            {
                float dist = (float)Math.Sqrt(obj_x * obj_x + obj_y * obj_y);
                if (dist < 10F)
                {
                    ww = 1.0F;
                }
                else
                {
                    if (dist > 30F)
                    {
                        ww = 0;
                    }
                    else
                    {
                        ww = 1.5F - dist / 20.0F;
                    }
                }
                Console.WriteLine("In front dist = " + dist.ToString() + " degree = " + ww.ToString());
            }
            return ww;
        }

        private static float matchToTheLeftOf(AliveObject obj, CD descr, DogsMind myMind)
        {
            float dog_x, dog_y, obj_x, obj_y;
            Console.WriteLine("Matching to the left of");
            concept descr_concept = descr.head;
            if (descr_concept == null) return 0;
            if (descr_concept.concept_name == "you") return matchOnYourLeft(obj, myMind);
            float best = 0;
            foreach (DictionaryEntry i in myMind.knownObjects)
            {
                string fam = (string)i.Key;
                concept obj_concept = (concept)concept.all_concepts[fam];
                if (obj_concept.test_isa(descr_concept) == true)
                {
                    Hashtable knownFamObjects = (Hashtable)i.Value;
                    foreach (DictionaryEntry j in knownFamObjects)
                    {
                        AliveObject obj2 = (AliveObject)j.Value;
                        float zz = matchObj(obj2, descr, myMind);
                        //transform the coordinates of the dog at the beginning of the task and of obj relative to the center of obj2
                        change_origin(obj2.X, obj2.Y, obj2.angle, myMind.myContext.start_pos_x, myMind.myContext.start_pos_y, out dog_x, out dog_y);
                        change_origin(obj2.X, obj2.Y, obj2.angle, obj.X, obj.Y, out obj_x, out obj_y);
                        if (!(dog_y * obj_x - dog_x * obj_y < 0))
                        {
                            float dist = distance(obj.X, obj.Y, obj2.X, obj2.Y);
                            float ww;
                            if (dist < 10F)
                            {
                                ww = 1.0F;
                            }
                            else
                            {
                                if (dist > 30F)
                                {
                                    ww = 0;
                                }
                                else
                                {
                                    ww = 1.5F - dist / 20.0F;
                                }
                            }
                            zz = zz * ww;
                            if (zz > best) best = zz;
                        }
                    }
                }
            }
            Console.WriteLine("Best conf for to the left of: " + best.ToString());
            return best;
        }

        private static float matchToTheRightOf(AliveObject obj, CD descr, DogsMind myMind)
        {
            float dog_x, dog_y, obj_x, obj_y;
            concept descr_concept = descr.head;
            Console.WriteLine("Matching to the right of");
            if (descr_concept == null) return 0;
            if (descr_concept.concept_name == "you") return matchOnYourRight(obj, myMind);
            float best = 0;
            foreach (DictionaryEntry i in myMind.knownObjects)
            {
                string fam = (string)i.Key;
                concept obj_concept = (concept)concept.all_concepts[fam];
                if (obj_concept.test_isa(descr_concept) == true)
                {
                    Hashtable knownFamObjects = (Hashtable)i.Value;
                    foreach (DictionaryEntry j in knownFamObjects)
                    {
                        AliveObject obj2 = (AliveObject)j.Value;
                        float zz = matchObj(obj2, descr, myMind);
                        //transform the coordinates of the dog at the beginning of the task and of obj relative to the center of obj2
                        change_origin(obj2.X, obj2.Y, obj2.angle, myMind.myContext.start_pos_x, myMind.myContext.start_pos_y, out dog_x, out dog_y);
                        change_origin(obj2.X, obj2.Y, obj2.angle, obj.X, obj.Y, out obj_x, out obj_y);
                        if (!(dog_y * obj_x - dog_x * obj_y > 0))
                        {
                            float dist = distance(obj.X, obj.Y, obj2.X, obj2.Y);
                            float ww;
                            if (dist < 10F)
                            {
                                ww = 1.0F;
                            }
                            else
                            {
                                if (dist > 30F)
                                {
                                    ww = 0;
                                }
                                else
                                {
                                    ww = 1.5F - dist / 20.0F;
                                }
                            }
                            zz = zz * ww;
                            if (zz > best) best = zz;
                        }
                    }
                }
            }
            Console.WriteLine("Best conf for to the right of: " + best.ToString());
            return best;
        }

        private static float matchOnYourLeft(AliveObject obj, DogsMind myMind)
        {
            float obj_x, obj_y, res;
            float dog_x = myMind.myContext.start_pos_x;
            float dog_y = myMind.myContext.start_pos_y;
            float dog_a = myMind.myDog.Orientation();
            Console.WriteLine("Matching on your left");
            //transform the coordinates of obj relative to the the dog
            change_origin(dog_x, dog_y, dog_a, obj.X, obj.Y, out obj_x, out obj_y);
            if (obj_x < .2) res = 1F;
            else res = 0;
            Console.WriteLine("Confidence for on your left: " + res.ToString());
            return res;
        }

        private static float matchOnYourRight(AliveObject obj, DogsMind myMind)
        {
            float obj_x, obj_y, res;
            float dog_x = myMind.myContext.start_pos_x;
            float dog_y = myMind.myContext.start_pos_y;
            float dog_a = myMind.myDog.Orientation();
            Console.WriteLine("Matching on your left");
            //transform the coordinates of obj relative to the the dog
            change_origin(dog_x, dog_y, dog_a, obj.X, obj.Y, out obj_x, out obj_y);
            if (obj_x > -.2) res = 1F;
            else res = 0;
            Console.WriteLine("Confidence for on your left: " + res.ToString());
            return res;
        }

        private static float matchToTheDirOf(AliveObject obj, CD descr, string dir, DogsMind myMind)
        {
            float dd, zz, yy;
            double ww;
            Console.WriteLine("Matching to the " + dir + " of");
            concept descr_concept = descr.head;
            if (descr_concept == null) return 0;
            if (descr_concept.concept_name == "you") return matchToYourDir(obj, dir, myMind);
            float best = 0;
            foreach (DictionaryEntry i in myMind.knownObjects)
            {
                string fam = (string)i.Key;
                concept obj_concept = (concept)concept.all_concepts[fam];
                if (obj_concept.test_isa(descr_concept) == true)
                {
                    Hashtable knownFamObjects = (Hashtable)i.Value;
                    foreach (DictionaryEntry j in knownFamObjects)
                    {
                        AliveObject obj2 = (AliveObject)j.Value;
                        zz = matchObj(obj2, descr, myMind);
                        dd = distance(obj.X, obj.Y, obj2.X, obj2.Y);
                        ww = .5 * (1 + 1 / Math.Log(Math.Max(dd, 3)));
                        yy = 0;
                        switch (dir)
                        {
                            case "north":
                                if (obj.Y > obj2.Y) yy = (float)ww;
                                break;
                            case "south":
                                if (obj.Y < obj2.Y) yy = (float)ww;
                                break;
                            case "east":
                                if (obj.X > obj2.X) yy = (float)ww;
                                break;
                            case "west":
                                if (obj.X < obj2.X) yy = (float)ww;
                                break;
                            default:
                                break;
                        }
                        zz = zz * yy;
                        if (zz > best) best = zz;
                    }
                }
            }
            Console.WriteLine("Best conf for to the " + dir + " of: " + best.ToString());
            return best;
        }

        private static float matchToYourDir(AliveObject obj, string dir, DogsMind myMind)
        {
            float res, ds;
            double ww;
            float dog_x = myMind.myContext.start_pos_x;
            float dog_y = myMind.myContext.start_pos_y;
            Console.WriteLine("Matching " + dir + " of you");
            ds = distance(obj.X, obj.Y, dog_x, dog_y);
            ww = .5 * (1 + 1 / Math.Log(Math.Max(ds, 3)));
            res = 0;
            switch (dir)
            {
                case "north":
                    if (obj.Y > dog_y) res = (float)ww;
                    break;
                case "south":
                    if (obj.Y < dog_y) res = (float)ww;
                    break;
                case "east":
                    if (obj.X > dog_x) res = (float)ww;
                    break;
                case "west":
                    if (obj.X < dog_x) res = (float)ww;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Confidence for " + dir + " of you: " + res.ToString());
            return res;
        }

        //===========================================================================================
        // Selecting objects that match the description

        public static float selectKnowObject(DogsMind dm, CD descr, out AliveObject res)
        {
            res = null;
            concept descr_concept = descr.head;
            if (descr_concept == null) return 0;
            Console.WriteLine("Select Known Object matching: " + descr.ToSexp());
            Console.WriteLine(dogPos(dm));
            float best = 0;
            float best_dist = 500F;
            foreach (DictionaryEntry i in dm.knownObjects)
            {
                string fam = (string)i.Key;
                concept obj_concept = (concept)concept.all_concepts[fam];
                if (obj_concept.test_isa(descr_concept) || descr_concept.test_isa(obj_concept))
                {
                    Hashtable knownFamObjects = (Hashtable)i.Value;
                    foreach (DictionaryEntry j in knownFamObjects)
                    {
                        AliveObject obj = (AliveObject)j.Value;
                        float zz = matchObj(obj, descr, dm);
                        if (zz > best)
                        {
                            best = zz;
                            res = obj;
                        }
                        else
                        {
                            if (zz == best) //all being equal, pick the nearest
                            {
                                float dogx;
                                float dogy;
                                dm.myDog.Coordinates(out dogx, out dogy);
                                float ds = distance(obj.X, obj.Y, dogx, dogy);
                                if (ds < best_dist)
                                {
                                    best_dist = ds;
                                    res = obj;
                                }
                            }
                        }
                    }
                }
            }
            if (res == null) Console.WriteLine("No known object matches the description");
            else Console.WriteLine("Best match is " + res.name + " degree = " + best.ToString());
            return best;
        }

        public static string dogPos(DogsMind dm)
        {
            float dx, dy, rot;
            dm.myDog.Coordinates(out dx, out dy);
            rot = dm.myDog.Orientation();
            string res = "Dog's position = <" + dx.ToString() + "," + dy.ToString() + "> Rotation = " + rot.ToString();
            return res;
        }


        public static ArrayList selectKnowObjects(DogsMind dm, CD descr)
        {
            Console.WriteLine("Selecting reference objects: " + descr.ToSexp());
            ArrayList res = new ArrayList();
            concept descr_concept = descr.head;
            if (descr_concept == null) return res;
            float conf = .5F;
            foreach (DictionaryEntry i in dm.knownObjects)
            {
                string fam = (string)i.Key;
                concept obj_concept = (concept)concept.all_concepts[fam];
                if (obj_concept.test_isa(descr_concept) || descr_concept.test_isa(obj_concept))
                {
                    Hashtable knownFamObjects = (Hashtable)i.Value;
                    foreach (DictionaryEntry j in knownFamObjects)
                    {
                        AliveObject obj = (AliveObject)j.Value;
                        float zz = matchObj(obj, descr, dm);
                        if (zz > conf)
                        {
                            res.Add(obj);
                        }
                    }
                }
            }
            Console.WriteLine("Found " + res.Count.ToString() + " reference objects");
            return res;
        }

        //This method is called when no known combination of objects matches target-cd
        //The dog needs to explore further and looks for a unexplore grid point
        //in the right direction and near a suitable object, if appropriate
        public static bool find_unexplored(DogsMind myMind, CD target_cd, out int dest_x, out int dest_y, int lim)
        {
            float search_dir = findSearchDir(myMind, target_cd); //search dir > 360 means that no search dir was specified
            float best_dist = findBestDest(myMind, target_cd, search_dir, out dest_x, out dest_y, lim);
            if (best_dist < 500)
            {
                Console.WriteLine("Found an unexplored point at: <" + dest_x.ToString() + "," + dest_y.ToString() + ">");
                return true;
            }
            Console.WriteLine("Could not find any unexplored points near reference objects");
            bool found = findPoint10(myMind, search_dir, out dest_x, out dest_y, lim);
            if (found == true) return true;
            Console.WriteLine("Looking for any unexplored point around the dog");
            return myMind.unexplored(out dest_x, out dest_y);
        }



        // finds search direction (in degrees) relative to the dog's starting position
        // 0 degrees means north, 90 degrees means east
        // search direction > 360 degrees means that the direction was not specified
        private static float findSearchDir(DogsMind myMind, CD target_cd)
        {
            Hashtable plist = target_cd.PropList;
            string[] dirs = { "front", "behind", "left", "right", "north", "south", "east", "west" };
            foreach (string prop in dirs)
            {
                CD rel_cd = (CD)plist[prop];
                if (rel_cd != null)
                {
                    concept descr_concept = rel_cd.head;
                    if (descr_concept != null && descr_concept.concept_name == "you")
                    {
                        float search_dir = computeSearchDir(prop, myMind);
                        Console.WriteLine("Search direction " + search_dir.ToString());
                        return search_dir;
                    }
                }
            }
            return 400F;
        }

        private static float computeSearchDir(string prop, DogsMind myMind)
        {
            float angle = myMind.myContext.start_angle;
            float res = angle; //0 degrees means North, 90 degrees - East
            switch (prop)
            {
                case "front":
                    res = angle;
                    break;
                case "behind":
                    res = angle + 180;
                    break;
                case "left":
                    res = angle + 270;
                    break;
                case "right":
                    res = angle + 90;
                    break;
                case "east":
                    res = 90;
                    break;
                case "west":
                    res = 270;
                    break;
                case "north":
                    res = 0;
                    break;
                case "south":
                    res = 180;
                    break;
                default:
                    break;
            }
            if (res >= 360) res = res - 360;
            return res;
        }

        //goes through all known objects that match a reference (if any) in the target description looking for
        //an unexplored point nearest the dog's current position
        private static float findBestDest(DogsMind myMind, CD target_cd, float search_dir, out int dest_x, out int dest_y, int lim)
        {
            Hashtable plist = target_cd.PropList;
            string[] rel_props = { "near", "behind", "front", "left", "right", "east", "west", "north", "south" };
            ArrayList cands = new ArrayList();
            float dist;
            float best_dist = 500F;
            float ox, oy, dx, dy, obj_x, obj_y;
            int tx, ty;
            bool right_dir = true;
            tx = 128;
            ty = 128;
            dest_x = 128;
            dest_y = 128;
            myMind.myDog.Coordinates(out dx, out dy);
            foreach (string key in rel_props)
            {
                CD rel_cd = (CD)plist[key];
                if (rel_cd != null && rel_cd.head != null && rel_cd.head.concept_name != "you")
                {
                    Console.WriteLine("Looking for an unexplored area near: " + rel_cd.ToSexp());
                    cands = selectKnowObjects(myMind, rel_cd);
                    foreach (object cand in cands)
                    {
                        AliveObject c = (AliveObject)cand;
                        ox = c.X;
                        oy = c.Y;
                        right_dir = true;
                        if (search_dir < 360)
                        //we virtually turn the dog in the search direction (at the task starting position)
                        //and check if the object is in front of it
                        {
                            float dog_x = myMind.myContext.start_pos_x;
                            float dog_y = myMind.myContext.start_pos_y;
                            change_origin(dog_x, dog_y, search_dir, ox, oy, out obj_x, out obj_y);
                            if (obj_y < 0) right_dir = false;
                        }
                        if (right_dir && find_unexplored_rel(myMind, ox, oy, out tx, out ty, lim) == true)
                        //We try to find an unexplored point within lim meters of the object
                        //we should also be checking if the point is in the right direction, but we don't
                        {
                            dist = distance(dx, dy, (float)tx, (float)ty); //prefer the closest to the dog
                            if (dist < best_dist)
                            {
                                best_dist = dist;
                                dest_x = tx;
                                dest_y = ty;
                            }
                        }
                    }
                }
            }
            return best_dist;
        }


        //look for an unexplored grid point around the point 10 meters in the search direction
        private static bool findPoint10(DogsMind myMind, float search_dir, out int dest_x, out int dest_y, int lim)
        {
            dest_x = 128;
            dest_y = 128;
            if (search_dir < 360)
            {
                float ox, oy, dx, dy;
                myMind.myDog.Coordinates(out dx, out dy);
                ox = dx + 10 * (float)Math.Sin((double)search_dir * Math.PI / 180);
                oy = dy + 10 * (float)Math.Cos((double)search_dir * Math.PI / 180);
                ox = Math.Max(myMind.min_x, ox);
                ox = Math.Min(myMind.max_x, ox);
                oy = Math.Max(myMind.min_y, oy);
                oy = Math.Min(myMind.max_y, oy);
                Console.WriteLine("Looking for any unexplored point 10 meters dir = " + search_dir.ToString() + " around " + "<" + ox.ToString() + "," + oy.ToString() + ">");
                if (find_unexplored_rel(myMind, ox, oy, out dest_x, out dest_y, lim) == true) return true;
            }
            return false;
        }

        //finds an unexplored grid point closest to <rel_x, rel_y> but within lim city blocks
        public static bool find_unexplored_rel(DogsMind myMind, float rel_x, float rel_y, out int xi, out int yi, int lim)
        {
            int cx, cy;
            int min_x = myMind.min_x;
            int min_y = myMind.min_y;
            int max_x = myMind.max_x;
            int max_y = myMind.max_y;
            xi = (int)Math.Round(rel_x);
            yi = (int)Math.Round(rel_y);
            if (xi < min_x || xi > max_x || yi < min_y || yi > max_y) return false;
            if (myMind.exploredMap[xi, yi] == false) return true;
            cx = xi;
            cy = yi;
            for (int i = 0; i < lim; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    xi = cx - j; // lower left quadrant
                    yi = cy - (i - j);
                    if (xi >= min_x && yi >= min_y && myMind.exploredMap[xi, yi] == false) return true;
                    yi = cy + 1 + (i - j); //upper left quadrant
                    if (xi >= min_x && yi <= max_y && myMind.exploredMap[xi, yi] == false) return true;
                    xi = cx + 1 + j; // lower right quadrant
                    yi = cy - (i - j);
                    if (xi <= max_x && yi >= min_y && myMind.exploredMap[xi, yi] == false) return true;
                    yi = cy + 1 + (i - j); // upper right quadrant
                    if (xi <= max_x && yi <= max_y && myMind.exploredMap[xi, yi] == false) return true;
                }
            }
            return false;
        }

        public static void change_origin(float c_x, float c_y, float angle, float old_x, float old_y, out float new_x, out float new_y)
        {
            double rad_angle = (double)angle * Math.PI / 180;
            new_x = (old_x - c_x) * (float)Math.Cos(rad_angle) + (old_y - c_y) * (float)Math.Sin(rad_angle);
            new_y = (-old_x + c_x) * (float)Math.Sin(rad_angle) + (old_y - c_y) * (float)Math.Cos(rad_angle);
        }
    }
}
