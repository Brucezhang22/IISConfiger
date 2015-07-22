using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.Administration;
using System.IO;
using System.Threading;

namespace IISConfiger
{
    public partial class IISConfigForm : Form
    {
        public IISConfigForm()
        {
            InitializeComponent();
        }
        TreeHelper treeHelper = new TreeHelper();

        private bool isFiltering = false;

        
        private TreeNode rootAssociatedSite = new TreeNode("关联网站");

        #region 工具方法
        #region 获取各级树节点
        /// <summary>
        /// 获取所有节点
        /// </summary>
        /// <returns></returns>
        private List<TreeNode> GetAllTreeNodes()
        {
            List<TreeNode> allTreeNodes = new List<TreeNode>();
            foreach (TreeNode node in TreeViewWebSite.Nodes)
            {
                treeHelper.AddNodesToList(node, ref allTreeNodes);
            }
            return allTreeNodes;
        }
        /// <summary>
        /// 获取所有除了根节点（“网站”）的其他节点
        /// </summary>
        /// <returns></returns>
        private IEnumerable<TreeNode> GetAllTreeNodesExceptRoot()
        {
            return GetAllTreeNodes().Where(n => ((Node)n.Tag).NodeType != NodeType.Root);
        }
        /// <summary>
        /// 获取所有的站点树节点
        /// </summary>
        /// <returns></returns>
        private IEnumerable<TreeNode> GetAllSiteNodes()
        {
            return GetAllTreeNodes().Where(n => ((Node)n.Tag).NodeType == NodeType.Site);
        }
        /// <summary>
        /// 获取所有的应用程序树节点
        /// </summary>
        /// <returns></returns>
        private IEnumerable<TreeNode> GetAllAppNodes()
        {
            return GetAllTreeNodes().Where(n => ((Node)n.Tag).NodeType == NodeType.Application);
        }
        /// <summary>
        /// 获取所有的虚拟路径树节点
        /// </summary>
        /// <returns></returns>
        private IEnumerable<TreeNode> GetAllVirtualDirNodes()
        {
            return GetAllTreeNodes().Where(n => ((Node)n.Tag).NodeType == NodeType.VirtualDirectory);
        }
        /// <summary>
        /// 获取所有选中网站节点
        /// </summary>
        /// <returns></returns>
        private IEnumerable<TreeNode> GetSelectedSiteNodes()
        {
            return GetAllTreeNodes().Where(n => n.Checked && ((Node)n.Tag).NodeType == NodeType.Site);
        }
        /// <summary>
        /// 获取所有选中的应用程序节点
        /// </summary>
        /// <returns></returns>
        private IEnumerable<TreeNode> GetSelectedAppNodes()
        {
            return GetAllTreeNodes().Where(n => n.Checked && ((Node)n.Tag).NodeType == NodeType.Application);
        }
        /// <summary>
        /// 获取所有选中的虚拟路径节点
        /// </summary>
        /// <returns></returns>
        private IEnumerable<TreeNode> GetSelectedVirDirNodes()
        {
            return GetAllTreeNodes().Where(n => n.Checked && ((Node)n.Tag).NodeType == NodeType.VirtualDirectory);
        }

        private IEnumerable<TreeNode> GetSelectedNoneWwwSiteNodes()
        {
            IEnumerable<TreeNode> selectdedNoneWwwNodes = GetAllTreeNodesExceptRoot().Where(n => n.Text.Contains("www.") == false && ((Node)n.Tag).NodeType == NodeType.Site && n.Checked);
            return selectdedNoneWwwNodes;
        }




        #endregion

        #region 获取各级站点的实例
        /// <summary>
        /// 获取所有网站的实例
        /// </summary>
        /// <returns></returns>
        private List<Site> GetSites(ServerManager serverManager)
        {
            List<Site> sites = new List<Site>();
            foreach (TreeNode treeNode in GetAllSiteNodes())
            {
                Node node = (Node)treeNode.Tag;
                sites.Add(serverManager.Sites[node.Site.Name]);
            }
            return sites;
        }
        /// <summary>
        /// 获取所有应用程序的实例
        /// </summary>
        /// <returns></returns>
        private List<Microsoft.Web.Administration.Application> GetApps(ServerManager serverManager)
        {
            List<Microsoft.Web.Administration.Application> apps = new List<Microsoft.Web.Administration.Application>();
            foreach (TreeNode treeNode in GetAllAppNodes())
            {
                Node node = (Node)treeNode.Tag;
                apps.Add(serverManager.Sites[node.Site.Name].Applications[node.Application.Path]);
            }
            return apps;
        }
        /// <summary>
        /// 获取所有虚拟路径的实例
        /// </summary>
        /// <returns></returns>
        private List<VirtualDirectory> GetVirtualDirs(ServerManager serverManager)
        {
            List<VirtualDirectory> virtualDirs = new List<VirtualDirectory>();
            foreach (TreeNode treeNode in GetAllVirtualDirNodes())
            {
                Node node = (Node)treeNode.Tag;
                virtualDirs.Add(serverManager.Sites[node.Site.Name].Applications[node.Application.Path].VirtualDirectories[node.VirtualDirectoty.Path]);
            }
            return virtualDirs;
        }

        /// <summary>
        /// 获取所有选中的网站的实例
        /// </summary>
        /// <returns></returns>
        private List<Site> GetSelectedSites(ServerManager serverManager)
        {
            List<Site> selectedSites = new List<Site>();
            foreach (TreeNode treeNode in GetSelectedSiteNodes())
            {
                Node node = (Node)treeNode.Tag;
                selectedSites.Add(serverManager.Sites[node.Site.Name]);
            }
            return selectedSites;
        }
        /// <summary>
        /// 获取所有选中的应用程序的实例
        /// </summary>
        /// <returns></returns>
        private List<Microsoft.Web.Administration.Application> GetSelectedApps(ServerManager serverManager)
        {
            List<Microsoft.Web.Administration.Application> selectedApps = new List<Microsoft.Web.Administration.Application>();
            foreach (TreeNode treeNode in GetSelectedAppNodes())
            {
                Node node = (Node)treeNode.Tag;
                selectedApps.Add(serverManager.Sites[node.Site.Name].Applications[node.Application.Path]);
            }
            return selectedApps;
        }
        /// <summary>
        /// 获取所有选中的虚拟路径的实例
        /// </summary>
        /// <returns></returns>
        private List<VirtualDirectory> GetSelectedVirtualDirs(ServerManager serverManager)
        {
            List<VirtualDirectory> selectedVirtualDirs = new List<VirtualDirectory>();
            foreach (TreeNode treeNode in GetSelectedVirDirNodes())
            {
                Node node = (Node)treeNode.Tag;
                selectedVirtualDirs.Add(serverManager.Sites[node.Site.Name].Applications[node.Application.Path].VirtualDirectories[node.VirtualDirectoty.Path]);
            }
            return selectedVirtualDirs;
        }
        #endregion

        #region 启动网站
        /// <summary>
        /// 启动网站
        /// </summary>
        /// <param name="treeview"></param>
        /// <param name="listbox"></param>
        private void StartSites(TreeView treeview, ListBox listbox)
        {

            IEnumerable<TreeNode> selectedSiteNodes = GetSelectedSiteNodes();
            if (selectedSiteNodes.Count() <= 0)
            {
                MessageBox.Show("请先选择要启动的网站！");
            }
            else
            {
                foreach (TreeNode node in selectedSiteNodes)
                {
                    Microsoft.Web.Administration.Site site = ((Node)node.Tag).Site;
                    if (site.State != ObjectState.Started)
                    {
                        try
                        {
                            site.Start();
                            listbox.Items.Add(string.Format("站点 {0} 启动，站点状态：{1}", site.Name, site.State.ToString()));
                        }
                        catch (Exception exception)
                        {
                            listBoxLogs.Items.Add(string.Format("站点 {0} 启动失败，错误详情：{1}", site.Name, exception));
                        }
                    }
                    else
                    {
                        listbox.Items.Add(string.Format("站点 {0} 已经启动，站点状态：{1}", site.Name, site.State.ToString()));
                    }
                }
            }
        }
        #endregion

        #region 停止网站
        /// <summary>
        /// 停止网站 
        /// </summary>
        /// <param name="treeview"></param>
        /// <param name="listbox"></param>
        private void StopSites(TreeView treeview, ListBox listbox)
        {
            IEnumerable<TreeNode> selectedSiteNodes = GetSelectedSiteNodes();
            if (selectedSiteNodes.Count() <= 0)
            {
                MessageBox.Show("请先选择要停止的网站！");
            }
            else
            {
                foreach (TreeNode node in selectedSiteNodes)
                {
                    Microsoft.Web.Administration.Site site = ((Node)node.Tag).Site;
                    if (site.State != ObjectState.Stopped)
                    {
                        try
                        {
                            site.Stop();
                            listbox.Items.Add(string.Format("站点 {0} 停止，站点状态：{1}", site.Name, site.State.ToString()));
                        }
                        catch (Exception exception)
                        {
                            listbox.Items.Add(string.Format("站点 {0} 停止失败，错误详情：{1}", site.Name, exception));
                        }
                    }
                    else
                    {
                        listbox.Items.Add(string.Format("站点 {0} 已经停止，站点状态：{1}", site.Name, site.State.ToString()));
                    }
                }
            }
        }
        #endregion

        #region 勾选、取消checkbox，设置节点状态
        /// <summary>
        /// 设置父节点的状态
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="state"></param>
        private void setParentNodeCheckState(TreeNode currentNode, bool state)
        {
            if (currentNode.Parent != null)
            {
                currentNode.Parent.Checked = state;
                setParentNodeCheckState(currentNode.Parent, state);
            }
        }
        /// <summary>
        /// 设置子节点的状态
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="state"></param>
        private void setChildNodeCheckState(TreeNode currentNode, bool state)
        {
            if (currentNode.Nodes.Count > 0)
            {
                foreach (TreeNode node in currentNode.Nodes)
                {
                    node.Checked = state;
                    setChildNodeCheckState(node, state);
                }
            }
        }
        #endregion

        #region 删除站点
        private void DeleteSite(TreeView treeview, ListBox listbox)
        {

            IEnumerable<TreeNode> selectedSites = GetSelectedSiteNodes();
            IEnumerable<TreeNode> selectedApps = GetSelectedAppNodes();
            IEnumerable<TreeNode> selectedVirDirs = GetSelectedVirDirNodes();
            if (selectedSites.Count() <= 0 && selectedApps.Count() <= 0 && selectedVirDirs.Count() <= 0)
            {
                MessageBox.Show("请先选择你删除的网站、应用程序或者虚拟路径！");
            }
            else
            {
                if (MessageBox.Show("确认删除站点，并删除站点物理路径下的文件? 删除后将无法自动还原。", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    #region 删除网站
                    if (selectedSites.Count() > 0)
                    {
                        using (ServerManager serverManager = new ServerManager())
                        {
                            foreach (TreeNode node in selectedSites)
                            {
                                Node n = (Node)node.Tag;
                                try
                                {
                                    Microsoft.Web.Administration.Site site = serverManager.Sites[n.Site.Name];
                                    serverManager.Sites.Remove(site);
                                    string physicalPath = site.Applications["/"].VirtualDirectories["/"].PhysicalPath;
                                    Directory.Delete(physicalPath, true);
                                    listbox.Items.Add(DateTime.Now.ToString() + ":" + string.Format("删除网站 {0}，并删除站点物理路径 {1} 下的所有文件 成功", site.Name, physicalPath));
                                }
                                catch (Exception exception)
                                {
                                    listbox.Items.Add(DateTime.Now.ToString() + ":" + string.Format("删除网站 {0} 失败,详细信息如下", n.Site.Name));
                                    listbox.Items.Add(exception);
                                }
                            }
                            serverManager.CommitChanges();
                        }
                    }
                    #endregion
                    #region 删除应用程序
                    if (selectedApps.Count() > 0)
                    {
                        using (ServerManager serverManager = new ServerManager())
                        {
                            foreach (TreeNode node in selectedApps)
                            {
                                Node n = (Node)node.Tag;
                                try
                                {
                                    Microsoft.Web.Administration.Application app = serverManager.Sites[n.Site.Name].Applications[n.Application.Path];
                                    serverManager.Sites[n.Site.Name].Applications.Remove(app);
                                    listbox.Items.Add(DateTime.Now.ToString() + ":" + string.Format("删除应用程序 {0} 成功", n.Path));
                                }
                                catch (Exception exception)
                                {
                                    listbox.Items.Add(DateTime.Now.ToString() + ":" + string.Format("删除应用程序 {0} 失败,详细信息如下", n.Path));
                                    listbox.Items.Add(exception);
                                }
                            }
                            serverManager.CommitChanges();
                        }
                    }
                    #endregion
                    #region 删除虚拟路径
                    if (selectedVirDirs.Count() > 0)
                    {
                        using (ServerManager serverManager = new ServerManager())
                        {
                            foreach (TreeNode node in selectedVirDirs)
                            {
                                Node n = (Node)node.Tag;
                                try
                                {
                                    VirtualDirectory virtualDir = serverManager.Sites[n.Site.Name].Applications[n.Application.Path].VirtualDirectories[n.VirtualDirectoty.Path];
                                    serverManager.Sites[n.Site.Name].Applications[n.Application.Path].VirtualDirectories.Remove(virtualDir);
                                    listbox.Items.Add(DateTime.Now.ToString() + ":" + string.Format("删除虚拟路径 {0} 成功", n.Path));
                                }
                                catch (Exception exception)
                                {
                                    listbox.Items.Add(DateTime.Now.ToString() + ":" + string.Format("删除虚拟路径 {0} 失败,详细信息如下", n.Path));
                                    listbox.Items.Add(exception);
                                }
                            }
                            serverManager.CommitChanges();
                        }
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region 设置Web.config配置文件中的HttpRedirect Element
        private static void SetHttpRedirectElement(bool enableChecked, string destination, bool enableExactDestination, bool enableChildOnly, string httpResponseStatus, Configuration config)
        {
            ConfigurationSection httpRedirectSection = config.GetSection("system.webServer/httpRedirect");
            httpRedirectSection["enabled"] = enableChecked;
            httpRedirectSection["destination"] = destination;
            httpRedirectSection["exactDestination"] = enableExactDestination;
            httpRedirectSection["childOnly"] = enableChildOnly;
            if (httpResponseStatus == "已找到（302）")
            {
                httpRedirectSection["httpResponseStatus"] = "Found";
            }
            else if (httpResponseStatus == "永久（301）")
            {
                httpRedirectSection["httpResponseStatus"] = "Permanent";
            }
            else
            {
                httpRedirectSection["httpResponseStatus"] = "Temporary";
            }
        }
        #endregion

        #region 判断一个Node是否配置了Http重定向
        /// <summary>
        /// 判断一个Node是否配置了Http重定向
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool enableHttpRedirect(Node node, ServerManager serverManager)
        {
            if (node.NodeType == NodeType.Site)
            {
                string siteName = node.Site.Name;
                Configuration config = serverManager.GetWebConfiguration(siteName);
                ConfigurationSection httpRedirectSection = config.GetSection("system.webServer/httpRedirect");
                return (bool)httpRedirectSection["enabled"];
            }
            else if (node.NodeType == NodeType.Application)
            {
                string siteName = node.Site.Name;
                string appPath = node.Application.Path;
                {
                    Configuration config = serverManager.GetWebConfiguration(siteName, appPath);
                    ConfigurationSection httpRedirectSection = config.GetSection("system.webServer/httpRedirect");
                    return (bool)httpRedirectSection["enabled"];
                }
            }
            else if (node.NodeType == NodeType.VirtualDirectory)
            {
                string siteName = node.Site.Name;
                string appPath = node.Application.Path;
                string virDirPath = node.VirtualDirectoty.Path;
                Configuration config = serverManager.GetWebConfiguration(siteName, appPath + virDirPath);
                ConfigurationSection httpRedirectSection = config.GetSection("system.webServer/httpRedirect");
                return (bool)httpRedirectSection["enabled"];
            }
            else if (node.NodeType == NodeType.Root)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 显示选中网站的基本信息
        private void ShowSiteInfo(TreeNode clickedNode, Node node)
        {
            if (node.NodeType == NodeType.Site)
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    string siteName = clickedNode.Text;
                    Microsoft.Web.Administration.Site site = serverManager.Sites[siteName];
                    string state = site.State.ToString();
                    string appPool = site.Applications["/"].ApplicationPoolName;
                    string physicalPath = site.Applications["/"].VirtualDirectories["/"].PhysicalPath;
                    Microsoft.Web.Administration.Binding[] bindingInfos = site.Bindings.ToArray();

                    Configuration config = serverManager.GetWebConfiguration(siteName);
                    ConfigurationSection httpRedirectSection = config.GetSection("system.webServer/httpRedirect");
                    bool enableChecked = (bool)httpRedirectSection["enabled"];
                    string destination = httpRedirectSection["destination"] as string;
                    bool enableExactDestination = (bool)httpRedirectSection["exactDestination"];
                    bool enableChildOnly = (bool)httpRedirectSection["childOnly"];
                    string httpResponseStatus = httpRedirectSection["httpResponseStatus"].ToString();

                    string[] siteInfoes = { string.Format("网站名称 ：{0}", siteName), string.Format("网站状态 ：{0}", state), string.Format("应用程序池：{0}", appPool), string.Format("物理路径 ：{0}", physicalPath) };
                    listBoxLogs.Items.AddRange(siteInfoes);
                    int i = 1;
                    foreach (Microsoft.Web.Administration.Binding binding in bindingInfos)
                    {
                        listBoxLogs.Items.Add(string.Format("绑定信息{0}：类型 {1}，主机名 {2}，IP {3}，端口 {4}", i, binding.Protocol, binding.Host, binding.EndPoint.Address, binding.EndPoint.Port));
                        i++;
                    }
                    listBoxLogs.Items.Add(string.Format("Http重定向：启用：{0}，目标：{1}，将所有请求重定向到确切的目标：{2}，仅将请求重定向到非子目录中的内容：{3}，状态代码：{4}", enableChecked, destination, enableExactDestination, enableChildOnly, httpResponseStatus));
                    listBoxLogs.Items.Add("");
                }
            }
        }
        #endregion

        #region 获取关联网站
        private void GetAssociatedSites()
        {
            List<TreeNode> allTreeNodes = GetAllTreeNodes();
            using (ServerManager serverManager = new ServerManager())
            {
                IEnumerable<TreeNode> allNodes = treeHelper.GetAllNodes(serverManager);
                IEnumerable<TreeNode> siteWithoutWWW = allNodes.Where(n => n.Text.StartsWith("www.", true, null) == false && string.IsNullOrEmpty(n.Text) == false);
                IEnumerable<TreeNode> siteWithWWW = allNodes.Where(n => n.Text.StartsWith("www.", true, null));

                UrlEqualityComparer comparer = new UrlEqualityComparer();

                IEnumerable<TreeNode> intersectionResult = siteWithoutWWW.Intersect(siteWithWWW, comparer);

                List<TreeNode> intersectionResult2 = new List<TreeNode>();

                foreach (TreeNode treenode in intersectionResult)
                {
                    intersectionResult2.Add(siteWithWWW.Where(n => n.Text == "www." + treenode.Text || n.Text == "WWW." + treenode.Text).FirstOrDefault());
                }

                IEnumerable<TreeNode> result3 = siteWithWWW.Except(intersectionResult2);
                IEnumerable<TreeNode> result4 = siteWithoutWWW.Except(intersectionResult);

                TreeViewWebSite.Nodes.Clear();
                rootAssociatedSite.Nodes.Clear();

                rootAssociatedSite.Tag = new Node { NodeType = NodeType.Root };
                rootAssociatedSite.ImageIndex = rootAssociatedSite.SelectedImageIndex = 9;

                TreeNode rootNoWWW = new TreeNode("已关联非www网站（" + intersectionResult.Count() + "个）");
                rootNoWWW.Tag = new Node { NodeType = NodeType.Root };
                rootNoWWW.ImageIndex = rootNoWWW.SelectedImageIndex = 9;

                TreeNode rootWWW = new TreeNode("已关联www网站（" + intersectionResult2.Count + "个）");
                rootWWW.Tag = new Node { NodeType = NodeType.Root };
                rootWWW.ImageIndex = rootWWW.SelectedImageIndex = 9;

                TreeNode rootNoWWWNotAssociated = new TreeNode("未关联非www网站（" + result4.Count() + "个）");
                rootNoWWWNotAssociated.Tag = new Node { NodeType = NodeType.Root };
                rootNoWWWNotAssociated.ImageIndex = rootNoWWWNotAssociated.SelectedImageIndex = 9;

                TreeNode rootWWWNotAssociated = new TreeNode("未关联www网站（" + result3.Count() + "个）");
                rootWWWNotAssociated.Tag = new Node { NodeType = NodeType.Root };
                rootWWWNotAssociated.ImageIndex = rootWWWNotAssociated.SelectedImageIndex = 9;

                TreeViewWebSite.Nodes.Add(rootAssociatedSite);

                rootAssociatedSite.Nodes.Add(rootNoWWW);
                rootAssociatedSite.Nodes.Add(rootWWW);
                rootAssociatedSite.Nodes.Add(rootNoWWWNotAssociated);
                rootAssociatedSite.Nodes.Add(rootWWWNotAssociated);

                rootNoWWW.Nodes.AddRange(intersectionResult.OrderBy(n => n.Text.Length).ToArray());
                rootWWW.Nodes.AddRange(intersectionResult2.OrderBy(n => n.Text.Length).ToArray());
                rootWWWNotAssociated.Nodes.AddRange(result3.OrderBy(n => n.Text.Length).ToArray());
                rootNoWWWNotAssociated.Nodes.AddRange(result4.OrderBy(n => n.Text.Length).ToArray());
            }
        }
        #endregion
        #endregion

        #region 窗口初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            treeHelper.ShowWebSiteTree(TreeViewWebSite, listBoxLogs);
            labelTitle.Text = "当前主机：" + Dns.GetHostName();
            panelBinding.Visible = false;
            panelHttpRedirect.Visible = false;
            comboBoxTypes.Items.AddRange(new object[] { "http", "https", "net.tcp", "net.pipe", "net.msmq", "msmq.formatname" });
            comboBoxhttpResponseStatus.Items.AddRange(new object[] { "已找到（302）", "永久（301)", "临时（307)" });
            using (ServerManager serverManager = new ServerManager())
            {
                foreach (ApplicationPool appPool in serverManager.ApplicationPools)
                {
                    comboBoxAppPools.Items.Add(appPool.Name);
                }
            }
            panelAppPool.Visible = false;
            string[] filterOptions = { "选择所有站点", "已启动站点", "已停止站点", "关联网站（如a.com和www.a.com）", "绑定配置多于一条的网站", "绑定配置含有关联【非www站点】的【www站点】", "未配置Http重定向的站点", "根据物理路径查找站点" };
            comboBoxFilterOptions.Items.AddRange(filterOptions);
            progressBar1.Visible = false;
            buttonStop.Visible = false;
            backgroundFilter.WorkerSupportsCancellation = true;
            filterAddressTextBox.Visible = false;
            filterAddressConfirm.Visible = false;
        }
        #endregion

        #region 点击【启动网站】启动选中的网站
        private void buttonStartsite_Click(object sender, EventArgs e)
        {
            StartSites(TreeViewWebSite, listBoxLogs);
        }
        #endregion

        #region 点击【停止网站】按钮，停止选中的网站
        private void buttonStopSite_Click(object sender, EventArgs e)
        {
            StopSites(TreeViewWebSite, listBoxLogs);
        }
        #endregion

        #region 点击【删除站点】，删除选中的网站、应用程序、虚拟目录
        private void ButtonDeleteSites_Click(object sender, EventArgs e)
        {
            DeleteSite(TreeViewWebSite, listBoxLogs);
            treeHelper.ShowWebSiteTree(TreeViewWebSite, listBoxLogs);
        }
        #endregion

        #region 点击【清空】按钮，清空日志文件
        private void buttonClearLogs_Click(object sender, EventArgs e)
        {
            listBoxLogs.Items.Clear();
        }
        #endregion

        #region 点击【导出】按钮导出日志文件
        private void buttonExportLogs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "保存操作日志";
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            saveFileDialog.ShowDialog();
            string path = saveFileDialog.FileName;
            if (!string.IsNullOrEmpty(path))
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in listBoxLogs.Items)
                {
                    stringBuilder.AppendLine(item.ToString());
                }
                using (FileStream filestream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffer = Encoding.Default.GetBytes(stringBuilder.ToString());
                    filestream.Write(buffer, 0, buffer.Length);
                }
                listBoxLogs.Items.Add(DateTime.Now.ToString() + "\t" + string.Format("导出日志到：{0}", path));
            }
            else
            {

            }
        }
        #endregion

        #region 点击【物理路径设置】为站点设置物理路径
        private void buttonPhysicalPath_Click(object sender, EventArgs e)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                List<Site> selectedSites = GetSelectedSites(serverManager);
                List<Microsoft.Web.Administration.Application> selectedApps = GetSelectedApps(serverManager);
                List<VirtualDirectory> selectedVirtualDires = GetSelectedVirtualDirs(serverManager);
                if (selectedSites.Count <= 0 && selectedApps.Count <= 0 && selectedVirtualDires.Count <= 0)
                {
                    MessageBox.Show("请先选择需要配置物理路径的网站、应用程序或者虚拟路径！");
                }
                else
                {
                    if (MessageBox.Show("该操作将为所选的网站、应用程序、虚拟路径设置相同的物理路径！", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        folderPhysicalPathDir.ShowDialog();
                        string physicalPath = folderPhysicalPathDir.SelectedPath;
                        if (!string.IsNullOrEmpty(physicalPath))
                        {
                            #region 为网站设置物理路径
                            if (selectedSites.Count > 0)
                            {
                                foreach (Site site in selectedSites)
                                {
                                    try
                                    {
                                        site.Applications["/"].VirtualDirectories["/"].PhysicalPath = physicalPath;
                                        listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("为站点 {0} 设置物理路径为： {1}", site.Name, physicalPath));
                                    }
                                    catch (Exception exception)
                                    {
                                        listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("为站点 {0} 设置物理路径失败，错误详情如下", site.Name));
                                        listBoxLogs.Items.Add(exception);
                                    }
                                }
                            }
                            #endregion
                            #region 为应用程序设置物理路径
                            if (selectedApps.Count > 0)
                            {
                                foreach (Microsoft.Web.Administration.Application app in selectedApps)
                                {
                                    try
                                    {
                                        app.VirtualDirectories["/"].PhysicalPath = physicalPath;
                                        listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("为应用程序 {0} 设置物理路径为： {1}", app.Path, physicalPath));
                                    }
                                    catch (Exception exception)
                                    {
                                        listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("为应用程序  {0} 设置物理路径失败，错误详情如下", app.Path));
                                        listBoxLogs.Items.Add(exception);
                                    }
                                }
                            }
                            #endregion
                            #region 为虚拟路径设置物理路径
                            if (selectedVirtualDires.Count > 0)
                            {
                                foreach (VirtualDirectory virtualDir in selectedVirtualDires)
                                {
                                    try
                                    {
                                        virtualDir.PhysicalPath = physicalPath;
                                        listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("为虚拟路径 {0} 设置物理路径为： {1}", virtualDir.Path, physicalPath));
                                    }
                                    catch (Exception exception)
                                    {
                                        listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("为虚拟路径  {0} 设置物理路径失败，错误详情如下", virtualDir.Path));
                                        listBoxLogs.Items.Add(exception);
                                    }
                                }
                            }
                            #endregion
                            serverManager.CommitChanges();
                        }
                    }
                }
            }
        }
        #endregion

        #region 【网站树形目录】相关
        #region 选择【过滤条件】,勾选符合过滤条件的站点
        private void comboBoxFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            isFiltering = true;
            string filter = comboBoxFilterOptions.SelectedItem.ToString();
            List<TreeNode> allTreeNodes = GetAllTreeNodes();
            #region 所有站点
            if (filter == "选择所有站点")
            {
                foreach (TreeNode treenode in allTreeNodes)
                {
                    treenode.Checked = true;
                }
            }
            #endregion
            #region 已启动站点
            else if (filter == "已启动站点")
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    IEnumerable<TreeNode> allSiteNodes = treeHelper.GetAllSiteNodes(serverManager);
                    IEnumerable<TreeNode> startedSiteNodes = allSiteNodes.Where(n => ((Node)n.Tag).Site.State == ObjectState.Started);
                    TreeViewWebSite.Nodes.Clear();
                    TreeNode rootStartedSites = new TreeNode("已启动站点（" + startedSiteNodes.Count() + "）个");
                    rootStartedSites.ImageIndex = rootStartedSites.SelectedImageIndex = 9;
                    rootStartedSites.Tag = new Node { NodeType = NodeType.Root };
                    TreeViewWebSite.Nodes.Add(rootStartedSites);
                    rootStartedSites.Nodes.AddRange(startedSiteNodes.OrderBy(n => n.Text.Length).ToArray());
                }
            }
            else if (filter == "根据物理路径查找站点")
            {
                filterAddressTextBox.Visible = true;
                filterAddressConfirm.Visible = true;
            }
            #endregion
            #region 已停止站点
            else if (filter == "已停止站点")
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    IEnumerable<TreeNode> allSiteNodes = treeHelper.GetAllSiteNodes(serverManager);
                    IEnumerable<TreeNode> stopedSiteNodes = allSiteNodes.Where(n => ((Node)n.Tag).Site.State == ObjectState.Stopped);
                    TreeViewWebSite.Nodes.Clear();
                    TreeNode rootStopedSites = new TreeNode("已停止站点（" + stopedSiteNodes.Count() + "）个");
                    rootStopedSites.ImageIndex = rootStopedSites.SelectedImageIndex = 9;
                    rootStopedSites.Tag = new Node { NodeType = NodeType.Root };
                    TreeViewWebSite.Nodes.Add(rootStopedSites);
                    rootStopedSites.Nodes.AddRange(stopedSiteNodes.OrderBy(n => n.Text.Length).ToArray());
                }
            }
            #endregion
            #region 未配置Http重定向的站点
            else if (filter == "未配置Http重定向的站点")
            {
                if ((MessageBox.Show("确定查找并勾选当前树形目录下所有未配置Http重定向的站点？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    backgroundFilter.RunWorkerAsync();
                }
            }
            #endregion
            #region 绑定配置多于一条的网站
            else if (filter == "绑定配置多于一条的网站")
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    IEnumerable<TreeNode> allSiteNodes = treeHelper.GetAllSiteNodes(serverManager);
                    IEnumerable<TreeNode> siteNodesWithMultiBindings = allSiteNodes.Where(n => ((Node)n.Tag).Site.Bindings.Count > 1);
                    TreeViewWebSite.Nodes.Clear();
                    TreeNode rootNodeMultiBindings = new TreeNode("绑定配置多于一条的网站（" + siteNodesWithMultiBindings.Count() + "）个");
                    rootNodeMultiBindings.ImageIndex = rootNodeMultiBindings.SelectedImageIndex = 9;
                    rootNodeMultiBindings.Tag = new Node { NodeType = NodeType.Root };
                    TreeViewWebSite.Nodes.Add(rootNodeMultiBindings);
                    rootNodeMultiBindings.Nodes.AddRange(siteNodesWithMultiBindings.OrderBy(n => n.Text.Length).ToArray());
                }
            }
            else if (filter == "绑定配置含有关联【非www站点】的【www站点】")
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    try
                    {
                        IEnumerable<TreeNode> allSiteNodes = treeHelper.GetAllSiteNodes(serverManager);
                        IEnumerable<TreeNode> wwwSiteNodes = allSiteNodes.Where(n => n.Text.StartsWith("www", true, null));
                        IEnumerable<TreeNode> wwwSiteNodesWithWrongBindings = wwwSiteNodes.Where(n => ((Node)n.Tag).Site.Bindings.Where(b => b.Host == n.Text.Substring(4)).Count() > 0);
                        TreeNode[] stops1 = wwwSiteNodesWithWrongBindings.Where(n => ((Node)n.Tag).Site.State == ObjectState.Stopped).OrderBy(n => n.Text).ToArray();
                        TreeNode[] started1 = wwwSiteNodesWithWrongBindings.Where(n => ((Node)n.Tag).Site.State == ObjectState.Started).OrderBy(n => n.Text).ToArray();


                        IEnumerable<TreeNode> siteWithoutWWW = allSiteNodes.Where(n => n.Text.StartsWith("www.", true, null) == false && string.IsNullOrEmpty(n.Text) == false);
                        UrlEqualityComparer comparer = new UrlEqualityComparer();
                        IEnumerable<TreeNode> intersectionResult = siteWithoutWWW.Intersect(wwwSiteNodesWithWrongBindings, comparer);
                        TreeNode[] stops2 = intersectionResult.Where(n => ((Node)n.Tag).Site.State == ObjectState.Stopped).OrderBy(n => n.Text).ToArray();
                        TreeNode[] started2 = intersectionResult.Where(n => ((Node)n.Tag).Site.State == ObjectState.Started).OrderBy(n => n.Text).ToArray();

                        TreeViewWebSite.Nodes.Clear();

                        TreeNode subrootStart1 = new TreeNode("已启动");
                        TreeNode subrootStop1 = new TreeNode("已停止");
                        TreeNode subrootStart2 = new TreeNode("已启动");
                        TreeNode subrootStop2 = new TreeNode("已停止");
                        subrootStart1.Tag = new Node { NodeType = NodeType.Root };
                        subrootStop1.Tag = new Node { NodeType = NodeType.Root };
                        subrootStart2.Tag = new Node { NodeType = NodeType.Root };
                        subrootStop2.Tag = new Node { NodeType = NodeType.Root };

                        subrootStart1.Nodes.AddRange(started1);
                        subrootStop1.Nodes.AddRange(stops1);
                        subrootStart2.Nodes.AddRange(started2);
                        subrootStop2.Nodes.AddRange(stops2);

                        TreeNode rootNodeMultiBindings = new TreeNode("绑定配置含有关联【非www站点】的【www站点】（" + wwwSiteNodesWithWrongBindings.Count() + "个）");
                        rootNodeMultiBindings.ImageIndex = rootNodeMultiBindings.SelectedImageIndex = 9;
                        rootNodeMultiBindings.Tag = new Node { NodeType = NodeType.Root };
                        rootNodeMultiBindings.Nodes.Add(subrootStart1);
                        rootNodeMultiBindings.Nodes.Add(subrootStop1);
                        TreeViewWebSite.Nodes.Add(rootNodeMultiBindings);

                        TreeNode rootNoWWW = new TreeNode("对应已关联非www网站（" + intersectionResult.Count() + "个）");
                        rootNoWWW.Tag = new Node { NodeType = NodeType.Root };
                        rootNoWWW.Nodes.Add(subrootStart2);
                        rootNoWWW.Nodes.Add(subrootStop2);
                        rootNoWWW.ImageIndex = rootNoWWW.SelectedImageIndex = 9;
                        TreeViewWebSite.Nodes.Add(rootNoWWW);
                    }
                    catch (Exception exception)
                    {
                        listBoxLogs.Items.Add(string.Format("获取数据失败，错误详情{0}", exception));
                    }
                }
            }
            #endregion
            #region 关联网站（如a.com和www.a.com）
            else if (filter == "关联网站（如a.com和www.a.com）")
            {
                GetAssociatedSites();
            }
            #endregion

            isFiltering = false;
        }



        #region 查找【未配置Http重定向的站点】 BackgroundFilter处理逻辑
        private void backgroundFilter_DoWork(object sender, DoWorkEventArgs e)
        {
            List<TreeNode> allTreeNodes = GetAllTreeNodes();
            int total = allTreeNodes.Count;
            int i = 1;
            foreach (TreeNode treenode in allTreeNodes)
            {
                if (!backgroundFilter.CancellationPending)
                {
                    using (ServerManager serverManager = new ServerManager())
                    {
                        Node node = (Node)treenode.Tag;
                        try
                        {
                            bool isHttpRedirectEnabled = enableHttpRedirect(node, serverManager);
                            Dictionary<TreeNode, bool> result = new Dictionary<TreeNode, bool>();
                            result.Add(treenode, isHttpRedirectEnabled);
                            backgroundFilter.ReportProgress(i * 100 / total, result);
                        }
                        catch (Exception exception)
                        {
                            Dictionary<TreeNode, Exception> result = new Dictionary<TreeNode, Exception>();
                            result.Add(treenode, exception);
                            backgroundFilter.ReportProgress(i * 100 / total, result);
                        }
                    }
                    i++;
                }
            }
        }
        private void backgroundFilter_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Visible = true;
            buttonStop.Visible = true;
            if (e.UserState is Dictionary<TreeNode, Exception>)
            {
                Dictionary<TreeNode, Exception> result = (Dictionary<TreeNode, Exception>)e.UserState;
                TreeNode treenode = result.FirstOrDefault().Key;
                Exception exception = result.FirstOrDefault().Value;
                treenode.Checked = true;
                listBoxLogs.Items.Add(exception);
            }
            else if (e.UserState is Dictionary<TreeNode, bool>)
            {
                Dictionary<TreeNode, bool> result = (Dictionary<TreeNode, bool>)e.UserState;
                TreeNode treenode = result.FirstOrDefault().Key;
                bool isHttpRedirectEnabled = result.FirstOrDefault().Value;
                if (!isHttpRedirectEnabled)
                {
                    treenode.Checked = true;
                    listBoxLogs.Items.Add(string.Format("找到未启用Http重定向的站点：{0}", treenode.Text));
                }
                else
                {
                    treenode.Checked = false;
                }
            }
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundFilter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int count = GetAllTreeNodesExceptRoot().Where(n => n.Checked).Count();
            listBoxLogs.Items.Add("查找完成！共找到未配置Http重定向的站点" + count + "个。");
            progressBar1.Value = 100;
        }

        #region 点击【停止】按钮，停止查询
        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (backgroundFilter.IsBusy)
            {
                backgroundFilter.CancelAsync();
            }
            else if (backgroundSiteHttpRedirect.IsBusy)
            {
                backgroundSiteHttpRedirect.CancelAsync();
            }
            else if (backgroundCreateSiteFolders.IsBusy)
            {
                backgroundCreateSiteFolders.CancelAsync();
            }
            else { }
            progressBar1.Value = 100;
        }
        #endregion

        #endregion
        #endregion

        #region 点击【checkboxes】选中站点、应用程序、虚拟路径
        private void TreeViewWebSite_AfterCheck_1(object sender, TreeViewEventArgs e)
        {
            if (isFiltering == false)
            {
                if (e.Node.Checked)
                {
                    setChildNodeCheckState(e.Node, true);
                }
                else if (!e.Node.Checked)
                {
                    setChildNodeCheckState(e.Node, false);
                }
                else
                {
                    setParentNodeCheckState(e.Node, false);
                }
            }
        }
        #endregion

        #region 点击【刷新】按钮，刷新网站树形目录
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            treeHelper.ShowWebSiteTree(TreeViewWebSite, listBoxLogs);
        }
        #endregion

        #region 点击【搜索】按钮，显示搜索结果列表
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                IEnumerable<TreeNode> allTreeNodes = treeHelper.GetAllNodes(serverManager);
                string keyword = comboBoxFilterOptions.Text;
                IEnumerable<TreeNode> result = allTreeNodes.Where(n => n.Text.ToUpper().Contains(keyword.ToUpper()));
                TreeViewWebSite.Nodes.Clear();
                TreeNode resultRoot = new TreeNode("搜索结果（" + keyword + ") " + result.Count() + "个");
                Node resultRootNode = new Node { NodeType = NodeType.Root };
                resultRoot.Tag = resultRootNode;
                resultRoot.ImageIndex = 7;
                resultRoot.SelectedImageIndex = 7;
                foreach (TreeNode treenode in result)
                {
                    resultRoot.Nodes.Add(treenode);
                }
                TreeViewWebSite.Nodes.Add(resultRoot);
            }
        }
        #endregion
        #endregion

        #region 【应用程序池】相关
        #region 点击【应用程序池设置】显示/隐藏应用程序池设置区域
        private void ButtonConfigAppPool_Click(object sender, EventArgs e)
        {
            panelAppPool.Visible = panelAppPool.Visible ? false : true;
        }
        #endregion

        #region 选中【应用程序池下拉列表】显示相应应用程序池信息
        private void comboBoxAppPools_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                string appPoolName = comboBoxAppPools.SelectedItem.ToString();
                ApplicationPool appPool = serverManager.ApplicationPools[appPoolName];
                labelFrameworkVersion.Text = appPool.ManagedRuntimeVersion;
                labelPipeLineMode.Text = appPool.ManagedPipelineMode.ToString();
            }
        }
        #endregion

        #region 点击【应用程序池-应用】按钮，为选中的网站和应用程序设置应用程序池
        private void buttonAppPoolSetConfirm_Click(object sender, EventArgs e)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                List<Site> selectedSites = GetSelectedSites(serverManager);
                List<Microsoft.Web.Administration.Application> selectedApps = GetSelectedApps(serverManager);
                if (selectedSites.Count <= 0 && selectedApps.Count <= 0)
                {
                    MessageBox.Show("请先选择需要配置应用程序池的网站或应用程序！");
                }
                else
                {
                    string appPoolName = comboBoxAppPools.SelectedItem.ToString();
                    #region 为网站设置应用程序池
                    if (selectedSites.Count > 0)
                    {
                        foreach (Site site in selectedSites)
                        {
                            try
                            {
                                site.Applications["/"].ApplicationPoolName = appPoolName;
                                listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("设置站点 {0} 的应用程序池为 {1}", site.Name, appPoolName));
                            }
                            catch (Exception exception)
                            {
                                listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("设置站点 {0} 的应用程序池为 {1}失败！错误详情如下:", site.Name, appPoolName));
                                listBoxLogs.Items.Add(exception);
                            }
                        }
                    }
                    #endregion
                    #region 为应用程序设置应用程序池
                    if (selectedApps.Count > 0)
                    {
                        foreach (Microsoft.Web.Administration.Application app in selectedApps)
                        {
                            try
                            {
                                app.ApplicationPoolName = appPoolName;
                                listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("设置应用程序 {0} 的应用程序池为 {1}", app.Path, appPoolName));
                            }
                            catch (Exception exception)
                            {
                                listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("设置应用程序 {0} 的应用程序池为 {1}失败！错误详情如下:", app.Path, appPoolName));
                                listBoxLogs.Items.Add(exception);
                            }
                        }
                    }
                    #endregion
                    serverManager.CommitChanges();
                }
            }
        }
        #endregion

        #region 点击【应用程序池-取消】按钮，隐藏应用程序池配置区域
        private void buttonAppPoolSetCancel_Click(object sender, EventArgs e)
        {
            panelAppPool.Visible = false;
        }
        #endregion
        #endregion

        #region 【Http重定向】相关
        #region 点击【Http重定向】按钮，显示或隐藏Http重定向配置区域
        private void buttonHttpRedirect_Click(object sender, EventArgs e)
        {
            panelBinding.Visible = panelHttpRedirect.Visible ? false : true;
            panelHttpRedirect.Visible = panelBinding.Visible;
        }
        #endregion

        #region 点击【Http重定向-应用】按钮，为选中的网站、应用程序、虚拟路径设置Http重定向
        private void buttonHttpRedirectApply_Click(object sender, EventArgs e)
        {
            IEnumerable<TreeNode> selectedSiteNodes = GetSelectedSiteNodes();
            IEnumerable<TreeNode> selectedAppNodes = GetSelectedAppNodes();
            IEnumerable<TreeNode> selectedVirtualDirNodes = GetSelectedVirDirNodes();
            if (selectedSiteNodes.Count() <= 0 && selectedAppNodes.Count() <= 0 && selectedVirtualDirNodes.Count() <= 0)
            {
                MessageBox.Show("请先选择需要配置Http重定向的网站、应用程序或者虚拟路径！");
            }
            else
            {
                bool enableChecked = checkBoxEnableHttpRequest.Checked;
                string destination = @textBoxDestinantion.Text;
                bool enableExactDestination = checkboxExactDestination.Checked;
                bool enableChildOnly = checkboxChildOnly.Checked;
                string httpResponseStatus = comboBoxhttpResponseStatus.SelectedItem as string;
                if (string.IsNullOrEmpty(destination) || string.IsNullOrEmpty(httpResponseStatus))
                {
                    MessageBox.Show("请设置重定向目标和状态代码！");
                }
                else
                {
                    HttpRedirectSettingParams settingParams = new HttpRedirectSettingParams
                    {
                        SelectedSiteNodes = selectedSiteNodes,
                        SelectedAppNodes = selectedAppNodes,
                        SelectedVirtualDirNodes = selectedVirtualDirNodes,
                        EnableChecked = enableChecked,
                        Destination = destination,
                        EnableExactDestination = enableExactDestination,
                        EnableChildOnly = enableChildOnly,
                        HttpResponseStatus = httpResponseStatus
                    };
                    backgroundSiteHttpRedirect.RunWorkerAsync(settingParams);

                }
            }
        }

        #region Backgroundworker逻辑
        private void backgroundSiteHttpRedirect_DoWork(object sender, DoWorkEventArgs e)
        {
            HttpRedirectSettingParams settingParams = (HttpRedirectSettingParams)e.Argument;
            IEnumerable<TreeNode> selectedSiteNodes = settingParams.SelectedSiteNodes;
            IEnumerable<TreeNode> selectedAppNodes = settingParams.SelectedAppNodes;
            IEnumerable<TreeNode> selectedVirtualDirNodes = settingParams.SelectedVirtualDirNodes;
            bool enableChecked = settingParams.EnableChecked;
            string destination = settingParams.Destination;
            bool enableExactDestination = settingParams.EnableExactDestination;
            bool enableChildOnly = settingParams.EnableChildOnly;
            string httpResponseStatus = settingParams.HttpResponseStatus;
            int totalCount = selectedSiteNodes.Count() + selectedAppNodes.Count() + selectedVirtualDirNodes.Count();
            #region 为网站设置Http重定向
            if (selectedSiteNodes.Count() > 0)
            {
                int i = 1;
                foreach (TreeNode siteNode in selectedSiteNodes)
                {
                    if (!backgroundSiteHttpRedirect.CancellationPending)
                    {
                        Node site = (Node)siteNode.Tag;
                        try
                        {
                            using (ServerManager serverManager = new ServerManager())
                            {
                                Configuration config = serverManager.GetWebConfiguration(site.Site.Name);
                                SetHttpRedirectElement(enableChecked, destination, enableExactDestination, enableChildOnly, httpResponseStatus, config);
                                string log = DateTime.Now.ToString() + ":" + string.Format("为站点 {0} 添加Http重定向,启用：{1},重定向目标：{2},定向到确切目标：{3},定向到非子目录中的内容：{4},状态代码：{5}", siteNode.Text, enableChecked, destination, enableExactDestination, enableChildOnly, httpResponseStatus);
                                backgroundSiteHttpRedirect.ReportProgress(i * 100 / totalCount, log);
                                serverManager.CommitChanges();
                            }
                        }
                        catch (Exception exception)
                        {
                            string log = DateTime.Now.ToString() + ":" + string.Format("为站点 {0} 添加Http重定向失败，错误详情如下", siteNode.Name) + exception.ToString();
                            backgroundSiteHttpRedirect.ReportProgress(i * 100 / totalCount, log);
                        }
                        i++;
                    }
                }
            }
            #endregion
            #region 为应用程序设置Http重定向
            if (selectedAppNodes.Count() > 0)
            {
                int i = selectedSiteNodes.Count() + 1;
                foreach (TreeNode appNode in selectedAppNodes)
                {
                    if (!backgroundSiteHttpRedirect.CancellationPending)
                    {
                        Node app = (Node)appNode.Tag;
                        try
                        {
                            using (ServerManager serverManager = new ServerManager())
                            {
                                Configuration config = serverManager.GetWebConfiguration(app.Site.Name, app.Application.Path);
                                SetHttpRedirectElement(enableChecked, destination, enableExactDestination, enableChildOnly, httpResponseStatus, config);
                                string log = DateTime.Now.ToString() + ":" + string.Format("为应用程序 {0} 添加Http重定向,启用：{1},重定向目标：{2},定向到确切目标：{3},定向到非子目录中的内容：{4},状态代码：{5}", app.Application.Path, enableChecked, destination, enableExactDestination, enableChildOnly, httpResponseStatus);
                                backgroundSiteHttpRedirect.ReportProgress(i * 100 / totalCount, log);
                                serverManager.CommitChanges();
                            }
                        }
                        catch (Exception exception)
                        {
                            string log = DateTime.Now.ToString() + ":" + string.Format("为应用程序 {0} 添加Http重定向失败，错误详情如下", app.Application.Path) + exception.ToString();
                            backgroundSiteHttpRedirect.ReportProgress(i * 100 / totalCount, log);
                        }
                        i++;
                    }
                }
            }
            #endregion
            #region 为虚拟路径设置Http重定向
            if (selectedVirtualDirNodes.Count() > 0)
            {
                int i = selectedSiteNodes.Count() + selectedAppNodes.Count() + 1;
                foreach (TreeNode treeNode in selectedVirtualDirNodes)
                {
                    if (!backgroundSiteHttpRedirect.CancellationPending)
                    {
                        Node node = (Node)treeNode.Tag;
                        string siteName = node.Site.Name;
                        string appPath = node.Application.Path;
                        string virtualDirPath = node.VirtualDirectoty.Path;
                        try
                        {
                            using (ServerManager serverManager = new ServerManager())
                            {
                                Configuration config = serverManager.GetWebConfiguration(siteName, appPath + virtualDirPath);
                                SetHttpRedirectElement(enableChecked, destination, enableExactDestination, enableChildOnly, httpResponseStatus, config);
                                string log = DateTime.Now.ToString() + ":" + string.Format("为虚拟路径 {0} 添加Http重定向,启用：{1},重定向目标：{2},定向到确切目标：{3},定向到非子目录中的内容：{4},状态代码：{5}", appPath + virtualDirPath, enableChecked, destination, enableExactDestination, enableChildOnly, httpResponseStatus);
                                backgroundSiteHttpRedirect.ReportProgress(i * 100 / totalCount, log);
                                serverManager.CommitChanges();
                            }
                        }
                        catch (Exception exception)
                        {
                            string log = DateTime.Now.ToString() + ":" + string.Format("为虚拟路径 {0} 添加Http重定向失败，错误详情如下", appPath + virtualDirPath) + exception.ToString();
                            backgroundSiteHttpRedirect.ReportProgress(i * 100 / totalCount, log);
                        }
                    }
                }
            }
            #endregion
        }

        private void backgroundSiteHttpRedirect_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Visible = true;
            buttonStop.Visible = true;
            progressBar1.Value = e.ProgressPercentage;
            string log = (string)e.UserState;
            listBoxLogs.Items.Add(log);
        }

        private void backgroundSiteHttpRedirect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBoxLogs.Items.Add("Http重定向设置完成！");
            progressBar1.Visible = false;
            buttonStop.Visible = false;
            GetAssociatedSites();
        }
        #endregion

        #endregion

        #region 点击【Http重定向配置-取消】按钮，隐藏Http重定向配置区域
        private void buttonHttpRequestCancel_Click(object sender, EventArgs e)
        {
            panelHttpRedirect.Visible = false;
            panelBinding.Visible = false;
        }
        #endregion

        #region 点击【Http重定向-关联网站】为关联网站配置Http重定向
        private void buttonHttpRedirectSpecific_Click(object sender, EventArgs e)
        {
            if (TreeViewWebSite.Nodes.Contains(rootAssociatedSite))
            {
                IEnumerable<TreeNode> selectedNoneWwwSiteNodes = GetSelectedNoneWwwSiteNodes();
                if (selectedNoneWwwSiteNodes.Count() <= 0)
                {
                    MessageBox.Show("请先选择需要配置Http重定向的站点");
                }
                else
                {
                    if (MessageBox.Show("确定为关联网站配置Http重定向？（如将contoso.com重定向到www.contoso.com）", "提示", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    {
                        backgroundAssociatedSiteHttpRedirect.RunWorkerAsync(selectedNoneWwwSiteNodes);

                    }
                }
            }
            else
            {
                MessageBox.Show("请先查找出需要配置Http重定向的关联网站！");
            }
        }
        private void backgroundAssociatedSiteHttpRedirect_DoWork(object sender, DoWorkEventArgs e)
        {
            IEnumerable<TreeNode> selectedNoneWwwSiteNodes = e.Argument as IEnumerable<TreeNode>;
            int i = 1;
            int totalCount = selectedNoneWwwSiteNodes.Count();
            foreach (TreeNode siteNode in selectedNoneWwwSiteNodes)
            {
                if (!backgroundAssociatedSiteHttpRedirect.CancellationPending)
                {
                    Node site = (Node)siteNode.Tag;
                    bool enableChecked = true;
                    string destination = string.Format("http://www.{0}", siteNode.Text);
                    bool enableExactDestination = false;
                    bool enableChildOnly = false;
                    string httpResponseStatus = "永久（301）";
                    try
                    {
                        using (ServerManager serverManager = new ServerManager())
                        {
                            Configuration config = serverManager.GetWebConfiguration(site.Site.Name);
                            SetHttpRedirectElement(enableChecked, destination, enableExactDestination, enableChildOnly, httpResponseStatus, config);
                            string log = DateTime.Now.ToString() + ":" + string.Format("为站点 {0} 添加Http重定向,启用：{1},重定向目标：{2},定向到确切目标：{3},定向到非子目录中的内容：{4},状态代码：{5}", siteNode.Text, enableChecked, destination, enableExactDestination, enableChildOnly, httpResponseStatus);
                            backgroundAssociatedSiteHttpRedirect.ReportProgress(i * 100 / totalCount, log);
                            serverManager.CommitChanges();
                        }
                    }
                    catch (Exception exception)
                    {
                        string log = DateTime.Now.ToString() + ":" + string.Format("为站点 {0} 添加Http重定向失败，错误详情如下", siteNode.Name) + exception.ToString();
                        backgroundSiteHttpRedirect.ReportProgress(i * 100 / totalCount, log);
                    }
                    i++;
                }
            }
        }
        private void backgroundAssociatedSiteHttpRedirect_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Visible = true;
            buttonStop.Visible = true;
            progressBar1.Value = e.ProgressPercentage;
            string log = (string)e.UserState;
            listBoxLogs.Items.Add(log);
        }
        private void backgroundAssociatedSiteHttpRedirect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBoxLogs.Items.Add("关联站点的Http重定向设置完成！");
            progressBar1.Visible = false;
            buttonStop.Visible = false;
            GetAssociatedSites();
        }
        #endregion

        #endregion

        #region 【域名绑定】相关
        #region 点击【域名绑定】按钮，显示或隐藏域名绑定配置区域
        private void buttonBindingDomain_Click(object sender, EventArgs e)
        {
            if (panelBinding.Visible == true && panelHttpRedirect.Visible == true)
            {
                panelHttpRedirect.Visible = false;
            }
            else
            {
                panelBinding.Visible = panelBinding.Visible ? false : true;
                panelHttpRedirect.Visible = false;
            }
        }
        #endregion

        #region 点击【绑定配置-确定】按钮，为网站添加绑定
        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                IEnumerable<TreeNode> selectedSites = GetSelectedSiteNodes();
                if (selectedSites.Count() <= 0 || comboBoxTypes.SelectedItem == null)
                {
                    MessageBox.Show("请先选择要配置绑定的站点,并配置正确的绑定信息");
                }
                else
                {
                    string type = comboBoxTypes.SelectedItem.ToString();
                    #region Type=http
                    if (type == "http")
                    {
                        string ip = textBoxIP.Text;
                        string port = textBoxPort.Text;
                        string domain = textBoxDomain.Text;
                        if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(port))
                        {
                            MessageBox.Show("请确认协议类型、IP地址、端口输入正确!");
                        }
                        else
                        {
                            foreach (TreeNode treeNode in selectedSites)
                            {
                                Node node = (Node)treeNode.Tag;
                                string siteName = node.Site.Name;
                                try
                                {
                                    Microsoft.Web.Administration.Site site = serverManager.Sites[siteName];
                                    if (site.Bindings.Where(b => b.Protocol == type && b.BindingInformation == ip + ":" + port + ":" + domain).Count() > 0)
                                    {
                                        listBoxLogs.Items.Add(string.Format("站点 {0} 已存在相同配置的绑定", siteName));
                                    }
                                    else
                                    {
                                        try
                                        {
                                            site.Bindings.Add(bindingProtocol: type, bindingInformation: ip + ":" + port + ":" + domain);
                                            listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("为站点 {0} 添加绑定,类型：{1},IP：{2},端口：{3},域名：{4}", siteName, type, ip, port, domain));
                                        }
                                        catch (Exception exception)
                                        {
                                            listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("为站点 {0} 添加绑定失败,错误详情如下类型：{1},IP：{2},端口：{3},域名：{4}", siteName, type, ip, port, domain));
                                            listBoxLogs.Items.Add(exception);
                                        }
                                    }
                                }
                                catch (Exception exception)
                                {
                                    listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("为站点 {0} 添加绑定失败,错误详情如下:类型：{1},IP：{2},端口：{3},域名：{4}", siteName, type, ip, port, domain));
                                    listBoxLogs.Items.Add(exception);
                                }
                            }
                        }
                    }
                    #endregion
                    #region Type=https
                    else if (type == "https")
                    {
                        string ip = textBoxIP.Text;
                        string port = textBoxPort.Text;
                        if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(port))
                        {
                            MessageBox.Show("请确认协议类型、IP地址、端口输入正确!");
                        }
                        else
                        {
                            foreach (TreeNode treeNode in selectedSites)
                            {
                                Node node = (Node)treeNode.Tag;
                                string siteName = node.Site.Name;
                                try
                                {
                                    Microsoft.Web.Administration.Site site = serverManager.Sites[siteName];
                                    if (site.Bindings.Where(b => b.Protocol == type && b.BindingInformation == ip + ":" + port + ":").Count() > 0)
                                    {
                                        listBoxLogs.Items.Add(string.Format("站点 {0} 已存在相同配置的绑定", siteName));
                                    }
                                    else
                                    {
                                        try
                                        {
                                            site.Bindings.Add(bindingProtocol: type, bindingInformation: ip + ":" + port + ":");
                                            listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("为站点 {0} 添加绑定,类型：{1},IP：{2},端口：{3}", siteName, type, ip, port));
                                        }
                                        catch (Exception exception)
                                        {
                                            listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("为站点 {0} 添加绑定失败,错误详情如下类型：{1},IP：{2},端口：{3}", siteName, type, ip, port));
                                            listBoxLogs.Items.Add(exception);
                                        }
                                    }
                                }
                                catch (Exception exception)
                                {
                                    listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("为站点 {0} 添加绑定失败,错误详情如下类型：{1},IP：{2},端口：{3}", siteName, type, ip, port));

                                    listBoxLogs.Items.Add(exception);
                                }

                            }
                        }
                    }
                    #endregion
                    #region 其他Type
                    else
                    {
                        string bindingInfo = textBoxBindingInfo.Text;
                        if (string.IsNullOrEmpty(bindingInfo))
                        {
                            MessageBox.Show("请输入绑定信息!");
                        }
                        else
                        {
                            foreach (TreeNode treeNode in selectedSites)
                            {
                                Node node = (Node)treeNode.Tag;
                                string siteName = node.Site.Name;
                                try
                                {
                                    Microsoft.Web.Administration.Site site = serverManager.Sites[siteName];
                                    if (site.Bindings.Where(b => b.Protocol == type && b.BindingInformation == bindingInfo).Count() > 0)
                                    {
                                        listBoxLogs.Items.Add(string.Format("站点 {0} 已存在相同配置的绑定", siteName));
                                    }
                                    else
                                    {
                                        try
                                        {
                                            site.Bindings.Add(bindingInformation: bindingInfo, bindingProtocol: type);
                                            listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("为站点 {0} 添加绑定,类型：{1},绑定信息：{2}", siteName, type, bindingInfo));
                                        }
                                        catch (Exception exception)
                                        {
                                            listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("为站点 {0} 添加绑定失败,错误详情如下类型：{1},绑定信息：{2}}", siteName, bindingInfo));
                                            listBoxLogs.Items.Add(exception);
                                        }
                                    }
                                }
                                catch (Exception exception)
                                {
                                    listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("为站点 {0} 添加绑定失败,错误详情如下", siteName));
                                    listBoxLogs.Items.Add(exception);
                                }
                            }
                        }
                    }
                    #endregion
                    serverManager.CommitChanges();
                }
            }
        }
        #endregion

        #region 点击【绑定配置-取消】按钮，隐藏绑定配置区域
        private void ButtonBindingCancel_Click(object sender, EventArgs e)
        {
            panelBinding.Visible = false;
        }
        #endregion

        #region 配置【绑定配置-类型】下拉框中的选项Enable，Disable
        private void comboBoxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = comboBoxTypes.GetItemText(comboBoxTypes.SelectedItem);
            if (type == "http")
            {
                textBoxBindingInfo.Enabled = false;
                textBoxDomain.Enabled = true;
                textBoxIP.Enabled = true;
                textBoxPort.Enabled = true;

            }
            else if (type == "https")
            {
                textBoxDomain.Enabled = false;
                textBoxIP.Enabled = true;
                textBoxPort.Enabled = true;
                textBoxBindingInfo.Enabled = false;
            }
            else
            {
                textBoxDomain.Enabled = false;
                textBoxIP.Enabled = false;
                textBoxPort.Enabled = false;
                textBoxBindingInfo.Enabled = true;
            }
        }
        #endregion

        #region 点击【删除绑定】按钮删除站点的域名绑定
        private void ButtonDeleteBinding_Click(object sender, EventArgs e)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                IEnumerable<TreeNode> selectedSiteNodes = GetSelectedSiteNodes();
                if (selectedSiteNodes.Count() <= 0)
                {
                    MessageBox.Show("请先选择要删除绑定的站点！");
                }
                else
                {
                    if (MessageBox.Show("该操作将会删除所有选中站点的最后一项绑定，请谨慎操作", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (TreeNode treeNode in selectedSiteNodes)
                        {
                            Node node = (Node)treeNode.Tag;
                            string siteName = node.Site.Name;
                            try
                            {
                                Microsoft.Web.Administration.Site site = serverManager.Sites[siteName];
                                Microsoft.Web.Administration.Binding bindingToBeRemoved = site.Bindings.LastOrDefault();
                                if (bindingToBeRemoved == null)
                                {
                                    listBoxLogs.Items.Add(DateTime.Now.ToString() + "\t" + string.Format("站点 {0} 未设置绑定", siteName));
                                }
                                else
                                {
                                    site.Bindings.Remove(bindingToBeRemoved);
                                    listBoxLogs.Items.Add(DateTime.Now.ToString() + "\t" + string.Format("站点 {0} 删除绑定，绑定信息:{1}", siteName, bindingToBeRemoved.BindingInformation));
                                }
                            }
                            catch (Exception exception)
                            {
                                listBoxLogs.Items.Add(DateTime.Now.ToString() + "\t" + string.Format("站点 {0} 删除绑定失败，错误详情如下", siteName));
                                listBoxLogs.Items.Add(exception);
                            }
                        }
                        serverManager.CommitChanges();
                    }
                }
            }
        }
        #endregion

        #endregion

        #region 【网站节点操作】相关
        #region 右击【网站节点】显示右键菜单
        private void TreeViewWebSite_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeViewWebSite.SelectedNode = e.Node;
                if (e.Node.Text.Contains("未关联www网站"))
                {
                    contextMenuStrip1.Enabled = true;
                }
                else if (e.Node.Text.Contains("绑定配置含有关联【非www站点】的【www站点】"))
                {
                    contextMenuStrip1.Enabled = true;
                    for (int i = 0; i < 3; i++)
                    {
                        contextMenuStrip1.Items[i].Enabled = false;
                    }
                }
                else if (e.Node.Text.Contains("已关联非www网站"))
                {
                    contextMenuStrip1.Enabled = true;
                    for (int i = 0; i < 4; i++)
                    {
                        contextMenuStrip1.Items[i].Enabled = false;
                    }
                }
                else
                {
                    contextMenuStrip1.Enabled = false;
                }
            }
        }
        #endregion

        #region 点击【为网站创建关联站点】右键菜单项，为www网站创建关联站点
        private void 为网站创建关联站点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnumerable<TreeNode> selectedWwwUnAssociatedSiteNodes = GetAllTreeNodesExceptRoot().Where(n => n.Parent.Text.Contains("未关联www网站") && n.Checked);
            if (selectedWwwUnAssociatedSiteNodes.Count() <= 0)
            {
                MessageBox.Show("未选中任何网站，请先选择需要配置关联站点的网站！");
            }
            else
            {
                folderPhysicalPathDir.Description = "请选择存放关联站点文件夹的路径";
                folderPhysicalPathDir.ShowDialog();
                string path = folderPhysicalPathDir.SelectedPath;
                if (!string.IsNullOrEmpty(path))
                {
                    if (MessageBox.Show(string.Format("将为选中网站创建关联站点，并在{0}下自动生成关联站点的文件夹", path), "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        backgroundCreateSiteFolders.RunWorkerAsync(path);
                    }
                }
            }
        }
        private void backgroundCreateSiteFolders_DoWork(object sender, DoWorkEventArgs e)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                string path = e.Argument as string;
                IEnumerable<TreeNode> selectedWwwUnAssociatedSiteNodes = GetAllTreeNodesExceptRoot().Where(n => n.Parent.Text.Contains("未关联www网站") && n.Checked);
                int i = 1;
                int total = selectedWwwUnAssociatedSiteNodes.Count();
                foreach (TreeNode treenode in selectedWwwUnAssociatedSiteNodes)
                {
                    if (!backgroundCreateSiteFolders.CancellationPending)
                    {
                        Node node = (Node)treenode.Tag;
                        string siteName = treenode.Text;
                        string domainType = siteName.Substring(siteName.LastIndexOf('.'));
                        string associatedSiteName = siteName.Substring(siteName.IndexOf('.') + 1, siteName.LastIndexOf('.') - siteName.IndexOf('.') - 1);
                        string folderName = associatedSiteName + "_a";
                        try
                        {
                            string bindingInfo = string.Format("*:{0}:{1}", 80, associatedSiteName + domainType);
                            serverManager.Sites.Add(name: associatedSiteName + domainType, bindingProtocol: "http", bindingInformation: bindingInfo, physicalPath: path + "\\" + folderName);
                            Directory.CreateDirectory(path + "\\" + folderName);
                            string log = string.Format("为网站：{0}创建关联站点{1}，并为关联站点添加目录{2}", siteName, associatedSiteName + domainType, path + "\\" + folderName);
                            backgroundCreateSiteFolders.ReportProgress(i * 100 / total, log);
                            serverManager.Sites[associatedSiteName + domainType].Applications["/"].VirtualDirectories["/"].PhysicalPath = path + "\\" + folderName;
                        }
                        catch (Exception exception)
                        {
                            string log = string.Format("为网站：{0}创建关联站点{1}失败！错误详情如下：{2}", siteName, associatedSiteName + domainType, exception.ToString());
                            backgroundCreateSiteFolders.ReportProgress(i * 100 / total, log);
                        }
                        i++;
                    }
                }
                serverManager.CommitChanges();
            }
        }
        private void backgroundCreateSiteFolders_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Visible = true;
            buttonStop.Visible = true;
            progressBar1.Value = e.ProgressPercentage;
            listBoxLogs.Items.Add(e.UserState.ToString());
        }
        private void backgroundCreateSiteFolders_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBoxLogs.Items.Add("为www网站创建关联站点完成！");
            progressBar1.Visible = false;
            buttonStop.Visible = false;
            GetAssociatedSites();
        }
        #endregion

        #region 点击【为网站创建目录】右键菜单项，为www网站创建文件目录
        private void 为网站创建文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnumerable<TreeNode> selectedWwwUnAssociatedSiteNodes = GetAllTreeNodesExceptRoot().Where(n => n.Text.Contains("www.") && n.Checked);
            if (selectedWwwUnAssociatedSiteNodes.Count() <= 0)
            {
                MessageBox.Show("未选中任何网站，请先选择需要配置关联站点的网站！");
            }
            else
            {
                folderPhysicalPathDir.Description = "请选择存放关联站点文件夹的路径";
                folderPhysicalPathDir.ShowDialog();
                string path = folderPhysicalPathDir.SelectedPath;
                if (!string.IsNullOrEmpty(path))
                {
                    if (MessageBox.Show(string.Format("将为选中网站创建关联站点，并在{0}下自动生成关联站点的文件夹", path), "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (ServerManager serverManager = new ServerManager())
                        {
                            foreach (TreeNode treenode in selectedWwwUnAssociatedSiteNodes)
                            {
                                string siteName = treenode.Text;
                                string mainName = siteName.Substring(siteName.IndexOf('.') + 1, siteName.LastIndexOf('.') - siteName.IndexOf('.') - 1);
                                Directory.CreateDirectory(path + "\\" + mainName);
                                serverManager.Sites[siteName].Applications["/"].VirtualDirectories["/"].PhysicalPath = path + "\\" + mainName;
                                listBoxLogs.Items.Add(siteName);
                            }
                            serverManager.CommitChanges();
                        }
                    }
                }
            }
        }
        #endregion

        #region 双击【网站节点】显示网站的基本信息
        private void TreeViewWebSite_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode clickedNode = e.Node;
            Node node = (Node)clickedNode.Tag;
            ShowSiteInfo(clickedNode, node);
        }
        #endregion

        #region 修复站点物理路径
        private void 修复站点物理路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnumerable<TreeNode> selectedNoneWwwSiteNodes = GetSelectedSiteNodes().Where(s => s.Parent.Text.Contains("已关联非www网站"));
            if (selectedNoneWwwSiteNodes.Count() <= 0)
            {
                MessageBox.Show("未选中任何网站，请先选择需要修复物理路径的网站！");
                return;
            }
            else
            {
                backgroundFixSitePhysicalPath.RunWorkerAsync();
            }
        }
        private void backgroundFixSitePhysicalPath_DoWork(object sender, DoWorkEventArgs e)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                IEnumerable<TreeNode> selectedNoneWwwSiteNodes = GetSelectedSiteNodes().Where(s => s.Parent.Text.Contains("已关联非www网站"));
                int total = selectedNoneWwwSiteNodes.Count();
                int i = 1;
                foreach (TreeNode node in selectedNoneWwwSiteNodes)
                {
                    string siteName = node.Text;
                    string wwwSiteName = "www." + siteName;
                    string mainName = siteName.Substring(0,siteName.LastIndexOf(".")) + "_a";
                    string currentPhysicalPath = serverManager.Sites[siteName].Applications["/"].VirtualDirectories["/"].PhysicalPath;
                    string wwwPhysicalPath = serverManager.Sites[wwwSiteName].Applications["/"].VirtualDirectories["/"].PhysicalPath;
                    string companyId = wwwPhysicalPath.Split('\\').Last();
                    if (currentPhysicalPath.Contains(mainName))
                    {
                        try
                        {
                            string[] filenames = Directory.GetFileSystemEntries(currentPhysicalPath);
                            string newPhysicalPath = currentPhysicalPath.Replace(mainName, companyId + "_a");

                            Directory.Move(currentPhysicalPath, newPhysicalPath);
                            serverManager.Sites[siteName].Applications["/"].VirtualDirectories["/"].PhysicalPath = newPhysicalPath;
                            string log = string.Format("将站点{0}的物理路径设置为{1}", siteName, newPhysicalPath);
                            backgroundFixSitePhysicalPath.ReportProgress(i * 100 / total, log);
                            i++;
                        }
                        catch (Exception ex)
                        {
                            string log = string.Format("修复站点物理路径失败:{0}", ex.Message);
                            backgroundFixSitePhysicalPath.ReportProgress(i * 100 / total, log);
                            i++;
                        }
                    }
                }
                serverManager.CommitChanges();
            }
        }
        private void backgroundFixSitePhysicalPath_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Visible = true;
            buttonStop.Visible = true;
            progressBar1.Value = e.ProgressPercentage;
            listBoxLogs.Items.Add(e.UserState.ToString());
        }
        private void backgroundFixSitePhysicalPath_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBoxLogs.Items.Add("修复站点物理路径完成！");
            progressBar1.Visible = false;
            buttonStop.Visible = false;
            GetAssociatedSites();
        }
        
        #endregion

        private void 选中拥有多条绑定配置的站点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnumerable<TreeNode> allWwwUnAssociatedSiteNodes =
                GetAllTreeNodesExceptRoot().Where(n => n.Parent.Text.Contains("未关联www网站"));
            IEnumerable<TreeNode> siteNodesWithMultiBindings = allWwwUnAssociatedSiteNodes.Where(n => ((Node)n.Tag).Site.Bindings.Count > 1);
            if (siteNodesWithMultiBindings.Count() > 0)
            {
                foreach (TreeNode node in siteNodesWithMultiBindings)
                {
                    node.Checked = true;
                }
            }
            listBoxLogs.Items.Add(string.Format("选中拥有多条绑定配置的站点{0}个", siteNodesWithMultiBindings.Count()));
        }
        #endregion

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnumerable<TreeNode> allWwwUnAssociatedSiteNodes =
                GetAllTreeNodesExceptRoot().Where(n => n.Parent.Text.Contains("未关联www网站") || n.Parent.Parent.Text.Contains("绑定配置含有关联【非www站点】的【www站点】"));
            IEnumerable<TreeNode> selectedSiteNodesWithMultiBindings = allWwwUnAssociatedSiteNodes.Where(n => ((Node)n.Tag).Site.Bindings.Count > 1 && n.Checked);
            using (ServerManager serverManager = new ServerManager())
            {
                if (MessageBox.Show("该操作将会删除选中站点主机名不含\"www\"的绑定，请谨慎操作", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (TreeNode treeNode in selectedSiteNodesWithMultiBindings)
                    {
                        Node node = (Node)treeNode.Tag;
                        string siteName = node.Site.Name;
                        try
                        {
                            Microsoft.Web.Administration.Site site = serverManager.Sites[siteName];
                            IEnumerable<Microsoft.Web.Administration.Binding> bindings = site.Bindings;
                            DeleteBinding(site, b => b.Host == siteName.Substring(4), listBoxLogs);
                        }
                        catch (Exception exception)
                        {
                            listBoxLogs.Items.Add(DateTime.Now.ToString() + ":" + string.Format("站点 {0} 删除绑定失败，错误详情如下", siteName));
                            listBoxLogs.Items.Add(exception);
                        }
                    }
                    serverManager.CommitChanges();
                }
            }
        }

        private void DeleteBinding(Site site, Func<Microsoft.Web.Administration.Binding, bool> condition, ListBox listbox)
        {
            IEnumerable<Microsoft.Web.Administration.Binding> bindings = site.Bindings;
            foreach (Microsoft.Web.Administration.Binding binding in bindings)
            {
                if (condition(binding))
                {
                    site.Bindings.Remove(binding);
                    listbox.Items.Add((DateTime.Now.ToString() + ":" + string.Format("站点 {0} 删除绑定，绑定信息:{1}", site.Name, binding.BindingInformation)));
                    break;
                }
            }
        }

        //按物理路径查找站点
        private void button1_Click(object sender, EventArgs e)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                string path = filterAddressTextBox.Text;
                IEnumerable<TreeNode> allSiteNodes = treeHelper.GetAllSiteNodes(serverManager);
                IEnumerable<TreeNode> siteNodesWithMultiBindings = allSiteNodes.Where(n => ((Node)n.Tag).Site.Applications["/"].VirtualDirectories["/"].PhysicalPath.Contains(path));
                TreeViewWebSite.Nodes.Clear();
                TreeNode rootNodeMultiBindings = new TreeNode("路径包含" + path + "的站点");
                rootNodeMultiBindings.ImageIndex = rootNodeMultiBindings.SelectedImageIndex = 9;
                rootNodeMultiBindings.Tag = new Node { NodeType = NodeType.Root };
                TreeViewWebSite.Nodes.Add(rootNodeMultiBindings);
                rootNodeMultiBindings.Nodes.AddRange(siteNodesWithMultiBindings.OrderBy(n => n.Text.Length).ToArray());
            }
        }
    }
}
    

