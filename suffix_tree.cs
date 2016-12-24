using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plagiarism_Detector
{
    class suffix_tree_operation
    {
        public class node   //nodes in tree
        {
            public int node_index_ = -1;
            public Dictionary<char, node> child = new Dictionary<char, node>();
        }

        public node root_ = new node();
        public String text_;

        public void add_new_suffix(string s, int index = 0)
        {
            var cur = root_;
            for (int i = index; i < s.Length; ++i)
            {
                var c = s[i];
                if (!cur.child.ContainsKey(c))
                {
                    var n = new node() { node_index_ = index };
                    cur.child.Add(c, n);

                    return;
                }
                cur = cur.child[c];
            }
            
        }


        private static IEnumerable<node> VisitTree(node n)
        {
            foreach (var n1 in n.child.Values)
                foreach (var n2 in VisitTree(n1))
                    yield return n2;
            yield return n;
        }

        public IEnumerable<int> Find(string s)
        {
            var n = FindNode(s);
            if (n == null) yield break;
            foreach (var n2 in VisitTree(n))
                yield return n2.node_index_;
        }

        private node FindNode(string s)
        {
            var cur = root_;
            for (int i = 0; i < s.Length; ++i)
            {
                var c = s[i];
                if (!cur.child.ContainsKey(c)) //to reach leaf node
                {
           
                    //check if the other part the string is at this location. 
                    for (var j = i; j < s.Length; ++j)
                        if (text_[cur.node_index_ + j] != s[j])
                            return null;
                    return cur;
                }
                cur = cur.child[c];
            }
            return cur;
        }

        public suffix_tree_operation(string s)
        {
            text_ = s;
            for (var i = s.Length - 1; i >= 0; --i)
                add_new_suffix(s, i);
        }
    }
}
