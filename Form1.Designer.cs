namespace IISConfiger
{
    partial class IISConfigForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IISConfigForm));
            this.panelBinding = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBindingInfo = new System.Windows.Forms.TextBox();
            this.labelBindingInfo = new System.Windows.Forms.Label();
            this.ButtonBindingCancel = new System.Windows.Forms.Button();
            this.ButtonConfirm = new System.Windows.Forms.Button();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.textBoxDomain = new System.Windows.Forms.TextBox();
            this.comboBoxTypes = new System.Windows.Forms.ComboBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelDomain = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.panelHttpRedirect = new System.Windows.Forms.Panel();
            this.checkBoxEnableHttpRequest = new System.Windows.Forms.CheckBox();
            this.comboBoxhttpResponseStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkboxChildOnly = new System.Windows.Forms.CheckBox();
            this.checkboxExactDestination = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDestinantion = new System.Windows.Forms.TextBox();
            this.buttonHttpRequestCancel = new System.Windows.Forms.Button();
            this.buttonHttpRedirectApply = new System.Windows.Forms.Button();
            this.buttonPhysicalPath = new System.Windows.Forms.Button();
            this.buttonHttpRedirect = new System.Windows.Forms.Button();
            this.buttonStartsite = new System.Windows.Forms.Button();
            this.buttonStopSite = new System.Windows.Forms.Button();
            this.ButtonDeleteBinding = new System.Windows.Forms.Button();
            this.buttonBindingDomain = new System.Windows.Forms.Button();
            this.ButtonDeleteSites = new System.Windows.Forms.Button();
            this.ButtonConfigAppPool = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxFilterOptions = new System.Windows.Forms.ComboBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.TreeViewWebSite = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.为网站创建关联站点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.为网站创建文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选中拥有多条绑定配置的站点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修复站点物理路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.filterAddressConfirm = new System.Windows.Forms.Button();
            this.filterAddressTextBox = new System.Windows.Forms.TextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonClearLogs = new System.Windows.Forms.Button();
            this.buttonExportLogs = new System.Windows.Forms.Button();
            this.listBoxLogs = new System.Windows.Forms.ListBox();
            this.folderPhysicalPathDir = new System.Windows.Forms.FolderBrowserDialog();
            this.panelAppPool = new System.Windows.Forms.Panel();
            this.buttonAppPoolSetCancel = new System.Windows.Forms.Button();
            this.buttonAppPoolSetConfirm = new System.Windows.Forms.Button();
            this.labelPipeLineMode = new System.Windows.Forms.Label();
            this.labelFrameworkVersion = new System.Windows.Forms.Label();
            this.labelPipeLineModeTitle = new System.Windows.Forms.Label();
            this.labelFrameworkVersionTitle = new System.Windows.Forms.Label();
            this.labelPropertiesTitle = new System.Windows.Forms.Label();
            this.comboBoxAppPools = new System.Windows.Forms.ComboBox();
            this.lableAppPoolTitle = new System.Windows.Forms.Label();
            this.backgroundFilter = new System.ComponentModel.BackgroundWorker();
            this.backgroundSiteHttpRedirect = new System.ComponentModel.BackgroundWorker();
            this.buttonHttpRedirectSpecific = new System.Windows.Forms.Button();
            this.backgroundAssociatedSiteHttpRedirect = new System.ComponentModel.BackgroundWorker();
            this.backgroundCreateSiteFolders = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundFixSitePhysicalPath = new System.ComponentModel.BackgroundWorker();
            this.panelBinding.SuspendLayout();
            this.panelHttpRedirect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panelAppPool.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBinding
            // 
            this.panelBinding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelBinding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBinding.Controls.Add(this.label2);
            this.panelBinding.Controls.Add(this.textBoxBindingInfo);
            this.panelBinding.Controls.Add(this.labelBindingInfo);
            this.panelBinding.Controls.Add(this.ButtonBindingCancel);
            this.panelBinding.Controls.Add(this.ButtonConfirm);
            this.panelBinding.Controls.Add(this.textBoxPort);
            this.panelBinding.Controls.Add(this.textBoxIP);
            this.panelBinding.Controls.Add(this.textBoxDomain);
            this.panelBinding.Controls.Add(this.comboBoxTypes);
            this.panelBinding.Controls.Add(this.labelPort);
            this.panelBinding.Controls.Add(this.labelIP);
            this.panelBinding.Controls.Add(this.labelDomain);
            this.panelBinding.Controls.Add(this.labelType);
            this.panelBinding.Location = new System.Drawing.Point(1, 449);
            this.panelBinding.Name = "panelBinding";
            this.panelBinding.Size = new System.Drawing.Size(244, 225);
            this.panelBinding.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "示例：www.contoso.com";
            // 
            // textBoxBindingInfo
            // 
            this.textBoxBindingInfo.Location = new System.Drawing.Point(61, 156);
            this.textBoxBindingInfo.Name = "textBoxBindingInfo";
            this.textBoxBindingInfo.Size = new System.Drawing.Size(176, 21);
            this.textBoxBindingInfo.TabIndex = 17;
            // 
            // labelBindingInfo
            // 
            this.labelBindingInfo.AutoSize = true;
            this.labelBindingInfo.Location = new System.Drawing.Point(3, 160);
            this.labelBindingInfo.Name = "labelBindingInfo";
            this.labelBindingInfo.Size = new System.Drawing.Size(65, 12);
            this.labelBindingInfo.TabIndex = 16;
            this.labelBindingInfo.Text = "绑定信息：";
            // 
            // ButtonBindingCancel
            // 
            this.ButtonBindingCancel.Location = new System.Drawing.Point(131, 193);
            this.ButtonBindingCancel.Name = "ButtonBindingCancel";
            this.ButtonBindingCancel.Size = new System.Drawing.Size(49, 21);
            this.ButtonBindingCancel.TabIndex = 15;
            this.ButtonBindingCancel.Text = "取消";
            this.ButtonBindingCancel.UseVisualStyleBackColor = true;
            this.ButtonBindingCancel.Click += new System.EventHandler(this.ButtonBindingCancel_Click);
            // 
            // ButtonConfirm
            // 
            this.ButtonConfirm.Location = new System.Drawing.Point(60, 193);
            this.ButtonConfirm.Name = "ButtonConfirm";
            this.ButtonConfirm.Size = new System.Drawing.Size(49, 21);
            this.ButtonConfirm.TabIndex = 14;
            this.ButtonConfirm.Text = "确定";
            this.ButtonConfirm.UseVisualStyleBackColor = true;
            this.ButtonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(61, 118);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(176, 21);
            this.textBoxPort.TabIndex = 13;
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(61, 81);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(176, 21);
            this.textBoxIP.TabIndex = 12;
            // 
            // textBoxDomain
            // 
            this.textBoxDomain.Location = new System.Drawing.Point(61, 39);
            this.textBoxDomain.Name = "textBoxDomain";
            this.textBoxDomain.Size = new System.Drawing.Size(176, 21);
            this.textBoxDomain.TabIndex = 11;
            // 
            // comboBoxTypes
            // 
            this.comboBoxTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypes.FormattingEnabled = true;
            this.comboBoxTypes.Location = new System.Drawing.Point(61, 6);
            this.comboBoxTypes.Name = "comboBoxTypes";
            this.comboBoxTypes.Size = new System.Drawing.Size(175, 20);
            this.comboBoxTypes.TabIndex = 10;
            this.comboBoxTypes.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypes_SelectedIndexChanged);
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(14, 122);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(41, 12);
            this.labelPort.TabIndex = 3;
            this.labelPort.Text = "端口：";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(14, 84);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(53, 12);
            this.labelIP.TabIndex = 2;
            this.labelIP.Text = "IP地址：";
            // 
            // labelDomain
            // 
            this.labelDomain.AutoSize = true;
            this.labelDomain.Location = new System.Drawing.Point(14, 42);
            this.labelDomain.Name = "labelDomain";
            this.labelDomain.Size = new System.Drawing.Size(41, 12);
            this.labelDomain.TabIndex = 1;
            this.labelDomain.Text = "域名：";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(14, 9);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(41, 12);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "类型：";
            // 
            // panelHttpRedirect
            // 
            this.panelHttpRedirect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelHttpRedirect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHttpRedirect.Controls.Add(this.checkBoxEnableHttpRequest);
            this.panelHttpRedirect.Controls.Add(this.comboBoxhttpResponseStatus);
            this.panelHttpRedirect.Controls.Add(this.label1);
            this.panelHttpRedirect.Controls.Add(this.checkboxChildOnly);
            this.panelHttpRedirect.Controls.Add(this.checkboxExactDestination);
            this.panelHttpRedirect.Controls.Add(this.label4);
            this.panelHttpRedirect.Controls.Add(this.textBoxDestinantion);
            this.panelHttpRedirect.Controls.Add(this.buttonHttpRequestCancel);
            this.panelHttpRedirect.Controls.Add(this.buttonHttpRedirectApply);
            this.panelHttpRedirect.Location = new System.Drawing.Point(1, 449);
            this.panelHttpRedirect.Name = "panelHttpRedirect";
            this.panelHttpRedirect.Size = new System.Drawing.Size(244, 225);
            this.panelHttpRedirect.TabIndex = 18;
            // 
            // checkBoxEnableHttpRequest
            // 
            this.checkBoxEnableHttpRequest.AutoSize = true;
            this.checkBoxEnableHttpRequest.Location = new System.Drawing.Point(8, 8);
            this.checkBoxEnableHttpRequest.Name = "checkBoxEnableHttpRequest";
            this.checkBoxEnableHttpRequest.Size = new System.Drawing.Size(144, 16);
            this.checkBoxEnableHttpRequest.TabIndex = 24;
            this.checkBoxEnableHttpRequest.Text = "将请求重定向到此目标";
            this.checkBoxEnableHttpRequest.UseVisualStyleBackColor = true;
            // 
            // comboBoxhttpResponseStatus
            // 
            this.comboBoxhttpResponseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxhttpResponseStatus.FormattingEnabled = true;
            this.comboBoxhttpResponseStatus.Location = new System.Drawing.Point(8, 160);
            this.comboBoxhttpResponseStatus.Name = "comboBoxhttpResponseStatus";
            this.comboBoxhttpResponseStatus.Size = new System.Drawing.Size(228, 20);
            this.comboBoxhttpResponseStatus.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "状态代码：";
            // 
            // checkboxChildOnly
            // 
            this.checkboxChildOnly.AutoSize = true;
            this.checkboxChildOnly.Location = new System.Drawing.Point(8, 106);
            this.checkboxChildOnly.Name = "checkboxChildOnly";
            this.checkboxChildOnly.Size = new System.Drawing.Size(204, 16);
            this.checkboxChildOnly.TabIndex = 21;
            this.checkboxChildOnly.Text = "仅将请求重定向到此目录中的内容";
            this.checkboxChildOnly.UseVisualStyleBackColor = true;
            // 
            // checkboxExactDestination
            // 
            this.checkboxExactDestination.AutoSize = true;
            this.checkboxExactDestination.Location = new System.Drawing.Point(8, 84);
            this.checkboxExactDestination.Name = "checkboxExactDestination";
            this.checkboxExactDestination.Size = new System.Drawing.Size(192, 16);
            this.checkboxExactDestination.TabIndex = 20;
            this.checkboxExactDestination.Text = "将所有请求重定向到确切的目标";
            this.checkboxExactDestination.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "示例：http://www.contoso.com/sales";
            // 
            // textBoxDestinantion
            // 
            this.textBoxDestinantion.Location = new System.Drawing.Point(8, 30);
            this.textBoxDestinantion.Name = "textBoxDestinantion";
            this.textBoxDestinantion.Size = new System.Drawing.Size(229, 21);
            this.textBoxDestinantion.TabIndex = 18;
            // 
            // buttonHttpRequestCancel
            // 
            this.buttonHttpRequestCancel.Location = new System.Drawing.Point(132, 193);
            this.buttonHttpRequestCancel.Name = "buttonHttpRequestCancel";
            this.buttonHttpRequestCancel.Size = new System.Drawing.Size(49, 21);
            this.buttonHttpRequestCancel.TabIndex = 15;
            this.buttonHttpRequestCancel.Text = "取消";
            this.buttonHttpRequestCancel.UseVisualStyleBackColor = true;
            this.buttonHttpRequestCancel.Click += new System.EventHandler(this.buttonHttpRequestCancel_Click);
            // 
            // buttonHttpRedirectApply
            // 
            this.buttonHttpRedirectApply.Location = new System.Drawing.Point(61, 193);
            this.buttonHttpRedirectApply.Name = "buttonHttpRedirectApply";
            this.buttonHttpRedirectApply.Size = new System.Drawing.Size(49, 21);
            this.buttonHttpRedirectApply.TabIndex = 14;
            this.buttonHttpRedirectApply.Text = "应用";
            this.buttonHttpRedirectApply.UseVisualStyleBackColor = true;
            this.buttonHttpRedirectApply.Click += new System.EventHandler(this.buttonHttpRedirectApply_Click);
            // 
            // buttonPhysicalPath
            // 
            this.buttonPhysicalPath.Location = new System.Drawing.Point(55, 151);
            this.buttonPhysicalPath.Name = "buttonPhysicalPath";
            this.buttonPhysicalPath.Size = new System.Drawing.Size(127, 23);
            this.buttonPhysicalPath.TabIndex = 41;
            this.buttonPhysicalPath.Text = "物理路径设置";
            this.buttonPhysicalPath.UseVisualStyleBackColor = true;
            this.buttonPhysicalPath.Click += new System.EventHandler(this.buttonPhysicalPath_Click);
            // 
            // buttonHttpRedirect
            // 
            this.buttonHttpRedirect.Location = new System.Drawing.Point(55, 209);
            this.buttonHttpRedirect.Name = "buttonHttpRedirect";
            this.buttonHttpRedirect.Size = new System.Drawing.Size(127, 23);
            this.buttonHttpRedirect.TabIndex = 40;
            this.buttonHttpRedirect.Text = "HTTP重定向";
            this.buttonHttpRedirect.UseVisualStyleBackColor = true;
            this.buttonHttpRedirect.Click += new System.EventHandler(this.buttonHttpRedirect_Click);
            // 
            // buttonStartsite
            // 
            this.buttonStartsite.Location = new System.Drawing.Point(55, 6);
            this.buttonStartsite.Name = "buttonStartsite";
            this.buttonStartsite.Size = new System.Drawing.Size(127, 23);
            this.buttonStartsite.TabIndex = 39;
            this.buttonStartsite.Text = "启动网站";
            this.buttonStartsite.UseVisualStyleBackColor = true;
            this.buttonStartsite.Click += new System.EventHandler(this.buttonStartsite_Click);
            // 
            // buttonStopSite
            // 
            this.buttonStopSite.Location = new System.Drawing.Point(55, 35);
            this.buttonStopSite.Name = "buttonStopSite";
            this.buttonStopSite.Size = new System.Drawing.Size(127, 23);
            this.buttonStopSite.TabIndex = 38;
            this.buttonStopSite.Text = "停止网站";
            this.buttonStopSite.UseVisualStyleBackColor = true;
            this.buttonStopSite.Click += new System.EventHandler(this.buttonStopSite_Click);
            // 
            // ButtonDeleteBinding
            // 
            this.ButtonDeleteBinding.Location = new System.Drawing.Point(55, 122);
            this.ButtonDeleteBinding.Name = "ButtonDeleteBinding";
            this.ButtonDeleteBinding.Size = new System.Drawing.Size(127, 23);
            this.ButtonDeleteBinding.TabIndex = 37;
            this.ButtonDeleteBinding.Text = "删除绑定";
            this.ButtonDeleteBinding.UseVisualStyleBackColor = true;
            this.ButtonDeleteBinding.Click += new System.EventHandler(this.ButtonDeleteBinding_Click);
            // 
            // buttonBindingDomain
            // 
            this.buttonBindingDomain.Location = new System.Drawing.Point(55, 93);
            this.buttonBindingDomain.Name = "buttonBindingDomain";
            this.buttonBindingDomain.Size = new System.Drawing.Size(127, 23);
            this.buttonBindingDomain.TabIndex = 36;
            this.buttonBindingDomain.Text = "域名绑定";
            this.buttonBindingDomain.UseVisualStyleBackColor = true;
            this.buttonBindingDomain.Click += new System.EventHandler(this.buttonBindingDomain_Click);
            // 
            // ButtonDeleteSites
            // 
            this.ButtonDeleteSites.Location = new System.Drawing.Point(55, 64);
            this.ButtonDeleteSites.Name = "ButtonDeleteSites";
            this.ButtonDeleteSites.Size = new System.Drawing.Size(127, 23);
            this.ButtonDeleteSites.TabIndex = 35;
            this.ButtonDeleteSites.Text = "删除站点";
            this.ButtonDeleteSites.UseVisualStyleBackColor = true;
            this.ButtonDeleteSites.Click += new System.EventHandler(this.ButtonDeleteSites_Click);
            // 
            // ButtonConfigAppPool
            // 
            this.ButtonConfigAppPool.Location = new System.Drawing.Point(55, 180);
            this.ButtonConfigAppPool.Name = "ButtonConfigAppPool";
            this.ButtonConfigAppPool.Size = new System.Drawing.Size(127, 23);
            this.ButtonConfigAppPool.TabIndex = 34;
            this.ButtonConfigAppPool.Text = "应用程序池设置";
            this.ButtonConfigAppPool.UseVisualStyleBackColor = true;
            this.ButtonConfigAppPool.Click += new System.EventHandler(this.ButtonConfigAppPool_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(247, -2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.TreeViewWebSite);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.filterAddressConfirm);
            this.splitContainer1.Panel2.Controls.Add(this.filterAddressTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.buttonStop);
            this.splitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel2.Controls.Add(this.buttonClearLogs);
            this.splitContainer1.Panel2.Controls.Add(this.buttonExportLogs);
            this.splitContainer1.Panel2.Controls.Add(this.listBoxLogs);
            this.splitContainer1.Size = new System.Drawing.Size(744, 680);
            this.splitContainer1.SplitterDistance = 248;
            this.splitContainer1.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.comboBoxFilterOptions);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 48);
            this.panel1.TabIndex = 7;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonSearch.Location = new System.Drawing.Point(211, 29);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(38, 20);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "搜索";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBoxFilterOptions
            // 
            this.comboBoxFilterOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFilterOptions.FormattingEnabled = true;
            this.comboBoxFilterOptions.Location = new System.Drawing.Point(-1, 29);
            this.comboBoxFilterOptions.Name = "comboBoxFilterOptions";
            this.comboBoxFilterOptions.Size = new System.Drawing.Size(210, 20);
            this.comboBoxFilterOptions.TabIndex = 6;
            this.comboBoxFilterOptions.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilterOptions_SelectedIndexChanged);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(-2, 8);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(29, 12);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "网站";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.Location = new System.Drawing.Point(211, 4);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(38, 20);
            this.buttonRefresh.TabIndex = 4;
            this.buttonRefresh.Text = "刷新";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // TreeViewWebSite
            // 
            this.TreeViewWebSite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeViewWebSite.CheckBoxes = true;
            this.TreeViewWebSite.ContextMenuStrip = this.contextMenuStrip1;
            this.TreeViewWebSite.FullRowSelect = true;
            this.TreeViewWebSite.ImageIndex = 2;
            this.TreeViewWebSite.ImageList = this.imageList1;
            this.TreeViewWebSite.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.TreeViewWebSite.Location = new System.Drawing.Point(0, 54);
            this.TreeViewWebSite.Name = "TreeViewWebSite";
            this.TreeViewWebSite.SelectedImageIndex = 0;
            this.TreeViewWebSite.Size = new System.Drawing.Size(249, 626);
            this.TreeViewWebSite.TabIndex = 0;
            this.TreeViewWebSite.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewWebSite_AfterCheck_1);
            this.TreeViewWebSite.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewWebSite_NodeMouseClick);
            this.TreeViewWebSite.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewWebSite_NodeMouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.为网站创建关联站点ToolStripMenuItem,
            this.为网站创建文ToolStripMenuItem,
            this.选中拥有多条绑定配置的站点ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.修复站点物理路径ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(234, 114);
            // 
            // 为网站创建关联站点ToolStripMenuItem
            // 
            this.为网站创建关联站点ToolStripMenuItem.Name = "为网站创建关联站点ToolStripMenuItem";
            this.为网站创建关联站点ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.为网站创建关联站点ToolStripMenuItem.Text = "为网站创建关联站点";
            this.为网站创建关联站点ToolStripMenuItem.Click += new System.EventHandler(this.为网站创建关联站点ToolStripMenuItem_Click);
            // 
            // 为网站创建文ToolStripMenuItem
            // 
            this.为网站创建文ToolStripMenuItem.Name = "为网站创建文ToolStripMenuItem";
            this.为网站创建文ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.为网站创建文ToolStripMenuItem.Text = "为网站创建目录";
            this.为网站创建文ToolStripMenuItem.Click += new System.EventHandler(this.为网站创建文ToolStripMenuItem_Click);
            // 
            // 选中拥有多条绑定配置的站点ToolStripMenuItem
            // 
            this.选中拥有多条绑定配置的站点ToolStripMenuItem.Name = "选中拥有多条绑定配置的站点ToolStripMenuItem";
            this.选中拥有多条绑定配置的站点ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.选中拥有多条绑定配置的站点ToolStripMenuItem.Text = "选中拥有多条绑定配置的站点";
            this.选中拥有多条绑定配置的站点ToolStripMenuItem.Click += new System.EventHandler(this.选中拥有多条绑定配置的站点ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.删除ToolStripMenuItem.Text = "删除主机名不含\"www\"的绑定";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 修复站点物理路径ToolStripMenuItem
            // 
            this.修复站点物理路径ToolStripMenuItem.Name = "修复站点物理路径ToolStripMenuItem";
            this.修复站点物理路径ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.修复站点物理路径ToolStripMenuItem.Text = "修复站点物理路径";
            this.修复站点物理路径ToolStripMenuItem.Click += new System.EventHandler(this.修复站点物理路径ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Site.jpg");
            this.imageList1.Images.SetKeyName(1, "Application.png");
            this.imageList1.Images.SetKeyName(2, "VirtualDir3.png");
            this.imageList1.Images.SetKeyName(3, "VirtualDir2.png");
            this.imageList1.Images.SetKeyName(4, "VirtualDirectory.jpg");
            this.imageList1.Images.SetKeyName(5, "rootNode.png");
            this.imageList1.Images.SetKeyName(6, "serach1.png");
            this.imageList1.Images.SetKeyName(7, "search2.png");
            this.imageList1.Images.SetKeyName(8, "serach3.png");
            this.imageList1.Images.SetKeyName(9, "serach4.png");
            this.imageList1.Images.SetKeyName(10, "serach5.jpg");
            this.imageList1.Images.SetKeyName(11, "mars.png");
            // 
            // filterAddressConfirm
            // 
            this.filterAddressConfirm.Location = new System.Drawing.Point(433, 28);
            this.filterAddressConfirm.Name = "filterAddressConfirm";
            this.filterAddressConfirm.Size = new System.Drawing.Size(56, 23);
            this.filterAddressConfirm.TabIndex = 26;
            this.filterAddressConfirm.Text = "确定";
            this.filterAddressConfirm.UseVisualStyleBackColor = true;
            this.filterAddressConfirm.Click += new System.EventHandler(this.button1_Click);
            // 
            // filterAddressTextBox
            // 
            this.filterAddressTextBox.Location = new System.Drawing.Point(3, 29);
            this.filterAddressTextBox.Name = "filterAddressTextBox";
            this.filterAddressTextBox.Size = new System.Drawing.Size(424, 21);
            this.filterAddressTextBox.TabIndex = 25;
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonStop.BackgroundImage")));
            this.buttonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonStop.Location = new System.Drawing.Point(348, 4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(38, 21);
            this.buttonStop.TabIndex = 24;
            this.buttonStop.Text = "停止";
            this.buttonStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(3, 9);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(339, 10);
            this.progressBar1.TabIndex = 23;
            // 
            // buttonClearLogs
            // 
            this.buttonClearLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearLogs.Location = new System.Drawing.Point(408, 4);
            this.buttonClearLogs.Name = "buttonClearLogs";
            this.buttonClearLogs.Size = new System.Drawing.Size(37, 21);
            this.buttonClearLogs.TabIndex = 22;
            this.buttonClearLogs.Text = "清空";
            this.buttonClearLogs.UseVisualStyleBackColor = true;
            this.buttonClearLogs.Click += new System.EventHandler(this.buttonClearLogs_Click);
            // 
            // buttonExportLogs
            // 
            this.buttonExportLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExportLogs.Location = new System.Drawing.Point(452, 4);
            this.buttonExportLogs.Name = "buttonExportLogs";
            this.buttonExportLogs.Size = new System.Drawing.Size(37, 21);
            this.buttonExportLogs.TabIndex = 21;
            this.buttonExportLogs.Text = "导出";
            this.buttonExportLogs.UseVisualStyleBackColor = true;
            this.buttonExportLogs.Click += new System.EventHandler(this.buttonExportLogs_Click);
            // 
            // listBoxLogs
            // 
            this.listBoxLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLogs.BackColor = System.Drawing.SystemColors.Window;
            this.listBoxLogs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxLogs.FormattingEnabled = true;
            this.listBoxLogs.HorizontalExtent = 10000;
            this.listBoxLogs.HorizontalScrollbar = true;
            this.listBoxLogs.ItemHeight = 12;
            this.listBoxLogs.Location = new System.Drawing.Point(3, 52);
            this.listBoxLogs.Name = "listBoxLogs";
            this.listBoxLogs.Size = new System.Drawing.Size(489, 628);
            this.listBoxLogs.TabIndex = 4;
            // 
            // panelAppPool
            // 
            this.panelAppPool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelAppPool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAppPool.Controls.Add(this.buttonAppPoolSetCancel);
            this.panelAppPool.Controls.Add(this.buttonAppPoolSetConfirm);
            this.panelAppPool.Controls.Add(this.labelPipeLineMode);
            this.panelAppPool.Controls.Add(this.labelFrameworkVersion);
            this.panelAppPool.Controls.Add(this.labelPipeLineModeTitle);
            this.panelAppPool.Controls.Add(this.labelFrameworkVersionTitle);
            this.panelAppPool.Controls.Add(this.labelPropertiesTitle);
            this.panelAppPool.Controls.Add(this.comboBoxAppPools);
            this.panelAppPool.Controls.Add(this.lableAppPoolTitle);
            this.panelAppPool.Location = new System.Drawing.Point(1, 281);
            this.panelAppPool.Name = "panelAppPool";
            this.panelAppPool.Size = new System.Drawing.Size(244, 154);
            this.panelAppPool.TabIndex = 5;
            // 
            // buttonAppPoolSetCancel
            // 
            this.buttonAppPoolSetCancel.Location = new System.Drawing.Point(131, 128);
            this.buttonAppPoolSetCancel.Name = "buttonAppPoolSetCancel";
            this.buttonAppPoolSetCancel.Size = new System.Drawing.Size(49, 21);
            this.buttonAppPoolSetCancel.TabIndex = 17;
            this.buttonAppPoolSetCancel.Text = "取消";
            this.buttonAppPoolSetCancel.UseVisualStyleBackColor = true;
            this.buttonAppPoolSetCancel.Click += new System.EventHandler(this.buttonAppPoolSetCancel_Click);
            // 
            // buttonAppPoolSetConfirm
            // 
            this.buttonAppPoolSetConfirm.Location = new System.Drawing.Point(60, 128);
            this.buttonAppPoolSetConfirm.Name = "buttonAppPoolSetConfirm";
            this.buttonAppPoolSetConfirm.Size = new System.Drawing.Size(49, 21);
            this.buttonAppPoolSetConfirm.TabIndex = 16;
            this.buttonAppPoolSetConfirm.Text = "应用";
            this.buttonAppPoolSetConfirm.UseVisualStyleBackColor = true;
            this.buttonAppPoolSetConfirm.Click += new System.EventHandler(this.buttonAppPoolSetConfirm_Click);
            // 
            // labelPipeLineMode
            // 
            this.labelPipeLineMode.AutoSize = true;
            this.labelPipeLineMode.Location = new System.Drawing.Point(76, 104);
            this.labelPipeLineMode.Name = "labelPipeLineMode";
            this.labelPipeLineMode.Size = new System.Drawing.Size(0, 12);
            this.labelPipeLineMode.TabIndex = 10;
            // 
            // labelFrameworkVersion
            // 
            this.labelFrameworkVersion.AutoSize = true;
            this.labelFrameworkVersion.Location = new System.Drawing.Point(138, 77);
            this.labelFrameworkVersion.Name = "labelFrameworkVersion";
            this.labelFrameworkVersion.Size = new System.Drawing.Size(0, 12);
            this.labelFrameworkVersion.TabIndex = 9;
            // 
            // labelPipeLineModeTitle
            // 
            this.labelPipeLineModeTitle.AutoSize = true;
            this.labelPipeLineModeTitle.Location = new System.Drawing.Point(16, 104);
            this.labelPipeLineModeTitle.Name = "labelPipeLineModeTitle";
            this.labelPipeLineModeTitle.Size = new System.Drawing.Size(65, 12);
            this.labelPipeLineModeTitle.TabIndex = 8;
            this.labelPipeLineModeTitle.Text = "管道模式：";
            // 
            // labelFrameworkVersionTitle
            // 
            this.labelFrameworkVersionTitle.AutoSize = true;
            this.labelFrameworkVersionTitle.Location = new System.Drawing.Point(13, 77);
            this.labelFrameworkVersionTitle.Name = "labelFrameworkVersionTitle";
            this.labelFrameworkVersionTitle.Size = new System.Drawing.Size(125, 12);
            this.labelFrameworkVersionTitle.TabIndex = 7;
            this.labelFrameworkVersionTitle.Text = ".Net Framework版本：";
            // 
            // labelPropertiesTitle
            // 
            this.labelPropertiesTitle.AutoSize = true;
            this.labelPropertiesTitle.Location = new System.Drawing.Point(5, 54);
            this.labelPropertiesTitle.Name = "labelPropertiesTitle";
            this.labelPropertiesTitle.Size = new System.Drawing.Size(41, 12);
            this.labelPropertiesTitle.TabIndex = 6;
            this.labelPropertiesTitle.Text = "属性：";
            // 
            // comboBoxAppPools
            // 
            this.comboBoxAppPools.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAppPools.FormattingEnabled = true;
            this.comboBoxAppPools.Location = new System.Drawing.Point(6, 25);
            this.comboBoxAppPools.Name = "comboBoxAppPools";
            this.comboBoxAppPools.Size = new System.Drawing.Size(230, 20);
            this.comboBoxAppPools.TabIndex = 5;
            this.comboBoxAppPools.SelectedIndexChanged += new System.EventHandler(this.comboBoxAppPools_SelectedIndexChanged);
            // 
            // lableAppPoolTitle
            // 
            this.lableAppPoolTitle.AutoSize = true;
            this.lableAppPoolTitle.Location = new System.Drawing.Point(4, 5);
            this.lableAppPoolTitle.Name = "lableAppPoolTitle";
            this.lableAppPoolTitle.Size = new System.Drawing.Size(77, 12);
            this.lableAppPoolTitle.TabIndex = 5;
            this.lableAppPoolTitle.Text = "应用程序池：";
            // 
            // backgroundFilter
            // 
            this.backgroundFilter.WorkerReportsProgress = true;
            this.backgroundFilter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundFilter_DoWork);
            this.backgroundFilter.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundFilter_ProgressChanged);
            this.backgroundFilter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundFilter_RunWorkerCompleted);
            // 
            // backgroundSiteHttpRedirect
            // 
            this.backgroundSiteHttpRedirect.WorkerReportsProgress = true;
            this.backgroundSiteHttpRedirect.WorkerSupportsCancellation = true;
            this.backgroundSiteHttpRedirect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundSiteHttpRedirect_DoWork);
            this.backgroundSiteHttpRedirect.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundSiteHttpRedirect_ProgressChanged);
            this.backgroundSiteHttpRedirect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundSiteHttpRedirect_RunWorkerCompleted);
            // 
            // buttonHttpRedirectSpecific
            // 
            this.buttonHttpRedirectSpecific.Location = new System.Drawing.Point(55, 238);
            this.buttonHttpRedirectSpecific.Name = "buttonHttpRedirectSpecific";
            this.buttonHttpRedirectSpecific.Size = new System.Drawing.Size(127, 23);
            this.buttonHttpRedirectSpecific.TabIndex = 43;
            this.buttonHttpRedirectSpecific.Text = "HTTP重定向-关联网站";
            this.buttonHttpRedirectSpecific.UseVisualStyleBackColor = true;
            this.buttonHttpRedirectSpecific.Click += new System.EventHandler(this.buttonHttpRedirectSpecific_Click);
            // 
            // backgroundAssociatedSiteHttpRedirect
            // 
            this.backgroundAssociatedSiteHttpRedirect.WorkerReportsProgress = true;
            this.backgroundAssociatedSiteHttpRedirect.WorkerSupportsCancellation = true;
            this.backgroundAssociatedSiteHttpRedirect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundAssociatedSiteHttpRedirect_DoWork);
            this.backgroundAssociatedSiteHttpRedirect.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundAssociatedSiteHttpRedirect_ProgressChanged);
            this.backgroundAssociatedSiteHttpRedirect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundAssociatedSiteHttpRedirect_RunWorkerCompleted);
            // 
            // backgroundCreateSiteFolders
            // 
            this.backgroundCreateSiteFolders.WorkerReportsProgress = true;
            this.backgroundCreateSiteFolders.WorkerSupportsCancellation = true;
            this.backgroundCreateSiteFolders.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundCreateSiteFolders_DoWork);
            this.backgroundCreateSiteFolders.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundCreateSiteFolders_ProgressChanged);
            this.backgroundCreateSiteFolders.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundCreateSiteFolders_RunWorkerCompleted);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // backgroundFixSitePhysicalPath
            // 
            this.backgroundFixSitePhysicalPath.WorkerReportsProgress = true;
            this.backgroundFixSitePhysicalPath.WorkerSupportsCancellation = true;
            this.backgroundFixSitePhysicalPath.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundFixSitePhysicalPath_DoWork);
            this.backgroundFixSitePhysicalPath.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundFixSitePhysicalPath_ProgressChanged);
            this.backgroundFixSitePhysicalPath.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundFixSitePhysicalPath_RunWorkerCompleted);
            // 
            // IISConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 677);
            this.Controls.Add(this.buttonHttpRedirectSpecific);
            this.Controls.Add(this.panelHttpRedirect);
            this.Controls.Add(this.panelAppPool);
            this.Controls.Add(this.panelBinding);
            this.Controls.Add(this.buttonPhysicalPath);
            this.Controls.Add(this.buttonHttpRedirect);
            this.Controls.Add(this.buttonStartsite);
            this.Controls.Add(this.buttonStopSite);
            this.Controls.Add(this.ButtonDeleteBinding);
            this.Controls.Add(this.buttonBindingDomain);
            this.Controls.Add(this.ButtonDeleteSites);
            this.Controls.Add(this.ButtonConfigAppPool);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IISConfigForm";
            this.Text = "烽火台-IIS配置工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelBinding.ResumeLayout(false);
            this.panelBinding.PerformLayout();
            this.panelHttpRedirect.ResumeLayout(false);
            this.panelHttpRedirect.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelAppPool.ResumeLayout(false);
            this.panelAppPool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBinding;
        private System.Windows.Forms.Panel panelHttpRedirect;
        private System.Windows.Forms.CheckBox checkBoxEnableHttpRequest;
        private System.Windows.Forms.ComboBox comboBoxhttpResponseStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkboxChildOnly;
        private System.Windows.Forms.CheckBox checkboxExactDestination;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDestinantion;
        private System.Windows.Forms.Button buttonHttpRequestCancel;
        private System.Windows.Forms.Button buttonHttpRedirectApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxBindingInfo;
        private System.Windows.Forms.Label labelBindingInfo;
        private System.Windows.Forms.Button ButtonBindingCancel;
        private System.Windows.Forms.Button ButtonConfirm;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.TextBox textBoxDomain;
        private System.Windows.Forms.ComboBox comboBoxTypes;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelDomain;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Button buttonPhysicalPath;
        private System.Windows.Forms.Button buttonHttpRedirect;
        private System.Windows.Forms.Button buttonStartsite;
        private System.Windows.Forms.Button buttonStopSite;
        private System.Windows.Forms.Button ButtonDeleteBinding;
        private System.Windows.Forms.Button buttonBindingDomain;
        private System.Windows.Forms.Button ButtonDeleteSites;
        private System.Windows.Forms.Button ButtonConfigAppPool;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TreeView TreeViewWebSite;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonClearLogs;
        private System.Windows.Forms.Button buttonExportLogs;
        private System.Windows.Forms.ListBox listBoxLogs;
        private System.Windows.Forms.FolderBrowserDialog folderPhysicalPathDir;
        private System.Windows.Forms.Panel panelAppPool;
        private System.Windows.Forms.Label labelPipeLineModeTitle;
        private System.Windows.Forms.Label labelFrameworkVersionTitle;
        private System.Windows.Forms.Label labelPropertiesTitle;
        private System.Windows.Forms.ComboBox comboBoxAppPools;
        private System.Windows.Forms.Label lableAppPoolTitle;
        private System.Windows.Forms.Label labelPipeLineMode;
        private System.Windows.Forms.Label labelFrameworkVersion;
        private System.Windows.Forms.Button buttonAppPoolSetCancel;
        private System.Windows.Forms.Button buttonAppPoolSetConfirm;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox comboBoxFilterOptions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.ComponentModel.BackgroundWorker backgroundFilter;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonStop;
        private System.ComponentModel.BackgroundWorker backgroundSiteHttpRedirect;
        private System.Windows.Forms.Button buttonHttpRedirectSpecific;
        private System.ComponentModel.BackgroundWorker backgroundAssociatedSiteHttpRedirect;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 为网站创建关联站点ToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundCreateSiteFolders;
        private System.Windows.Forms.ToolStripMenuItem 为网站创建文ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选中拥有多条绑定配置的站点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Button filterAddressConfirm;
        private System.Windows.Forms.TextBox filterAddressTextBox;
        private System.Windows.Forms.ToolStripMenuItem 修复站点物理路径ToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundFixSitePhysicalPath;
    }
}

