using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IISConfiger
{
    public enum NodeType
    {
        Root,
        Site,
        Application,
        VirtualDirectory,
        Unkonw
    }
    public class Node
    {
        private string path;
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                if (value.Contains("//"))
                {
                    this.path = value.Replace("//", "/");
                }
                else
                {
                    this.path = value;
                }
            }
        }
        public string Text { get; set; }
        public string ParentPath
        {
            get
            {
                if (this.Path.Contains("//"))
                {
                    return Path.Substring(0, Path.LastIndexOf("//"));
                }
                else if (this.Path.Contains('/'))
                {
                    return Path.Substring(0, Path.LastIndexOf('/'));
                }
                else
                {
                    return "网站";
                }
            }
        }
        public NodeType NodeType { get; set; }
        public Site Site { get; set; }
        public Microsoft.Web.Administration.Application Application { get; set; }
        public VirtualDirectory VirtualDirectoty { get; set; }
    }
}
