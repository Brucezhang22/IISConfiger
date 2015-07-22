using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;
using System.Windows.Forms;
using System.Drawing;

namespace IISConfiger
{
    public class TreeHelper
    {
        /// <summary>
        /// 获取所有的
        /// </summary>
        /// <param name="treenode"></param>
        /// <param name="treenodes"></param>
        public void AddNodesToList(TreeNode treenode,ref List<TreeNode> treenodes)
        {
            treenodes.Add(treenode);
            if (treenode.Nodes.Count > 0)
            {
                foreach (TreeNode node in treenode.Nodes)
                {
                    AddNodesToList(node,ref treenodes);
                }
            }
        }
        public IEnumerable<TreeNode> GetAllNodes(ServerManager serverManager)
        {
            return GetAllSiteNodes(serverManager).Concat(GetAllAppNodes(serverManager)).Concat(GetAllVirtualDirNodes(serverManager));
        }
        /// <summary>
        /// 获取所有的网站节点
        /// </summary>
        /// <param name="serverManager"></param>
        /// <returns></returns>
        public IEnumerable<TreeNode> GetAllSiteNodes(ServerManager serverManager)
        {
            List<TreeNode> siteTreeNotes = new List<TreeNode>(); 
            foreach (Site site in serverManager.Sites)
            {
                TreeNode siteTreeNode = new TreeNode(site.Name);
                siteTreeNode.Tag = new Node { Path = site.Name, NodeType = NodeType.Site, Site = site, Text = site.Name};
                siteTreeNode.ImageIndex = 0;
                siteTreeNode.SelectedImageIndex = 0;
                siteTreeNotes.Add(siteTreeNode);
            }
            return siteTreeNotes;
        }
        /// <summary>
        /// 获取所有的应用程序节点
        /// </summary>
        /// <param name="serverManager"></param>
        /// <returns></returns>
        public IEnumerable<TreeNode> GetAllAppNodes(ServerManager serverManager)
        {
            List<TreeNode> appTreeNodes = new List<TreeNode>();
            foreach (Site site in serverManager.Sites)
            {
                foreach (Microsoft.Web.Administration.Application app in site.Applications)
                {
                    TreeNode appTreeNode = new TreeNode(app.Path.Substring(app.Path.LastIndexOf('/') + 1));
                    appTreeNode.Tag = new Node { Path = site.Name + app.Path, NodeType = NodeType.Application, Site = site, Application = app,Text = app.Path.Substring(app.Path.LastIndexOf('/') + 1) };
                    appTreeNode.ImageIndex = 1;
                    appTreeNode.SelectedImageIndex = 1;
                    appTreeNodes.Add(appTreeNode);
                }
            }
            return appTreeNodes;
        }
        /// <summary>
        /// 获取所有的虚拟路径的节点
        /// </summary>
        /// <param name="serverManager"></param>
        /// <returns></returns>
        public IEnumerable<TreeNode> GetAllVirtualDirNodes(ServerManager serverManager)
        {
            List<TreeNode> virtuaTreelDirNodes = new List<TreeNode>();
            foreach (Site site in serverManager.Sites)
            {
                foreach (Microsoft.Web.Administration.Application app in site.Applications)
                {
                    foreach (VirtualDirectory virtualDir in app.VirtualDirectories)
                    {
                        TreeNode virDirTreeNode = new TreeNode(virtualDir.Path.Substring(virtualDir.Path.LastIndexOf('/') + 1));
                        virDirTreeNode.Tag = new Node { Path = site.Name + app.Path + virtualDir.Path, NodeType = NodeType.VirtualDirectory, Site = site, Application = app,VirtualDirectoty=virtualDir, Text = virtualDir.Path.Substring(virtualDir.Path.LastIndexOf('/') + 1) };
                        virDirTreeNode.ImageIndex = 2;
                        virDirTreeNode.SelectedImageIndex = 2;
                        virtuaTreelDirNodes.Add(virDirTreeNode);
                    }
                }
            }
            return virtuaTreelDirNodes;
        }
        /// <summary>
        /// 显示网站树形目录
        /// </summary>
        /// <param name="treeview"></param>
        public void ShowWebSiteTree(TreeView treeview,ListBox listBox)
        {
            treeview.Nodes.Clear();
            TreeNode rootNode = new TreeNode("网站");
            Node root = new Node { NodeType = NodeType.Root };
            rootNode.Tag = root;
            rootNode.ImageIndex = 5;
            rootNode.SelectedImageIndex = 5;
            treeview.Nodes.Add(rootNode);
            using (ServerManager serverManagerTemp = new ServerManager())
            {
                IEnumerable<TreeNode> allNodes = GetAllNodes(serverManagerTemp).Where(n => n.Text != "").OrderBy(n =>((Node)n.Tag).ParentPath.Count(c => c == '/')).AsEnumerable();
                foreach (TreeNode node in allNodes)
                {
                    node.Nodes.AddRange(allNodes.Where(n => ((Node)n.Tag).ParentPath == ((Node)node.Tag).Path).ToArray());
                    if (((Node)node.Tag).ParentPath == "网站")
                    {
                        rootNode.Nodes.Add(node);
                    }                  
                }
                rootNode.Text = "网站（" + GetAllSiteNodes(serverManagerTemp).Count() + "个)";
            }
        }
    }
}
