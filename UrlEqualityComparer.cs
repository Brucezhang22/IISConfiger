using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IISConfiger
{
    public class UrlEqualityComparer:IEqualityComparer<TreeNode>
    {
        public bool Equals(TreeNode x, TreeNode y)
        {
            if ("www."+x.Text==y.Text || "www."+y.Text==x.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(TreeNode obj)
        {
            return obj.Index.GetHashCode();
        }
    }

}
