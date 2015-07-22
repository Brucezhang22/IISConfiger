using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IISConfiger
{
    public class HttpRedirectSettingParams
    {
        public IEnumerable<TreeNode> SelectedSiteNodes { get; set; }
        public IEnumerable<TreeNode> SelectedAppNodes { get; set; }
        public IEnumerable<TreeNode> SelectedVirtualDirNodes { get; set; }

        public bool EnableChecked { get; set; }
        public string Destination { get; set; }
        public bool EnableExactDestination { get; set; }
        public bool EnableChildOnly { get; set; }
        public string HttpResponseStatus { get; set; }
    }
}
