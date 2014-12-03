using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kaldi
{
    public class ParseTreeNode
    {
    }

    public class ParseTreeTokenNode : ParseTreeNode
    {
        private readonly string value;

        public string Value
        {
            get
            {
                return value;
            }
        }
		
		public override string ToString()
		{
			return value;
		}

        internal ParseTreeTokenNode(string value)
        {
            this.value = value;
        }
    }

    public class ParseTreeRuleNode : ParseTreeNode
    {
        private static readonly int RuleNameStartIndex = 2;
        private static readonly int RuleDescriptionSeparatorLength = 2;

        private readonly string name;
        private readonly string grammar;
        private readonly List<ParseTreeNode> children;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Grammar
        {
            get
            {
                return grammar;
            }
        }

        public IList<ParseTreeNode> Children
        {
            get
            {
                return children.AsReadOnly();
            }
        }

        public ParseTreeRuleNode(string parseString)
        {
            Queue<string> tokens = new Queue<string>(parseString.Trim().Split(' '));
            ParseRuleNode(tokens, out this.name, out this.grammar, out this.children);
        }
		
		public ParseTreeRuleNode FindChildRule(string name)
		{
			foreach (ParseTreeNode child in children) {
				if (child is ParseTreeRuleNode) {
					ParseTreeRuleNode ruleChild = (ParseTreeRuleNode) child;
					if (ruleChild.Name == name) return ruleChild;
				}
			}
			return null;
		}

        private ParseTreeRuleNode(string name, string grammar, List<ParseTreeNode> children)
        {
            this.name = name;
            this.grammar = grammar;
            this.children = children;
        }

        private void ParseRuleNode(Queue<string> tokens, out string name, out string grammar, out List<ParseTreeNode> children)
        {
            string descriptionToken = tokens.Dequeue();

            int nameEndIndexExclusive = descriptionToken.IndexOf(']');
            name = descriptionToken.Substring(RuleNameStartIndex, nameEndIndexExclusive - RuleNameStartIndex);
            
            int grammarStartIndex = nameEndIndexExclusive + RuleDescriptionSeparatorLength + 1;
            int grammarEndIndexExclusive = descriptionToken.LastIndexOf('}');
            grammar = descriptionToken.Substring(grammarStartIndex, grammarEndIndexExclusive - grammarStartIndex);

            if (tokens.Dequeue() != "(") throw new ArgumentException("invalid tokens: missing opening parenthesis after rule description");

            children = new List<ParseTreeNode>();
            while (tokens.Peek() != ")")
            {
                if (tokens.Peek().StartsWith("{"))
                {
                    string childName, childGrammar;
                    List<ParseTreeNode> childChildren;
                    ParseRuleNode(tokens, out childName, out childGrammar, out childChildren);
                    children.Add(new ParseTreeRuleNode(childName, childGrammar, childChildren));
                }
                else
                {
                    children.Add(new ParseTreeTokenNode(tokens.Dequeue()));
                }
            }
            tokens.Dequeue(); // ")"
        }
    }
}
