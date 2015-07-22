/*----------------------------------------------------------------

// Copyright © 2013 All Rights Reserved.
//
// 文件名：FileHelper.cs
// 功能描述：
//
// 创建时间：2013/9/2 9:43:57
//
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace IISConfiger
{
    public class FileHelper
    {
        //获得文件扩展名
        public static string GetFileExt(string fullPath)
        {
            if (fullPath != "")
                return fullPath.Substring(fullPath.LastIndexOf('.') + 1).ToLower();
            else
                return "";
        }

        //创建文件夹
        public static void CreateFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        /// <summary>
        /// base64编码的文本转为文件
        /// </summary>
        /// <param name="path">保存的文件路径</param>
        /// <param name="fileName">保存的路径的文件名</param>
        /// <param name="file">要转换的文本</param>
        /// <remarks>base64编码的文本转为文件</remarks>
        public static string SaveBase64ToFile(string path, string fileName, string file)
        {
            try
            {
                path = path + fileName;
                Stream fs = FromBase64String(path,file);
                fs.Close();
                return path;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        /// 获取base64编码的文件文本
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <remarks>返回文件的base64编码</remarks>
        public static string GetBase64ToFile(string path)
        {
            try
            {
                var fs = System.IO.File.OpenRead(path);
                var br = new System.IO.BinaryReader(fs);
                string base64String = Convert.ToBase64String(br.ReadBytes((int)fs.Length));
                br.Close();
                fs.Close();
                return base64String;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// 获取时间戳 当文件名
        /// </summary>
        /// <returns></returns>
        public static string GetFileNameByTime()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        /// <summary>
        /// 删除一个文件
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// 返回一个只读流
        /// </summary>
        /// <param name="filepath">文件的路径</param>
        /// <param name="content">文件的二进制形式</param>
        /// <returns></returns>
        public static Stream FromBase64String(string filepath,string content)
        {
            const int BufferSize = 1024 * 8;

            //临时文件
            string file = filepath;
            try
            {
                using (Stream sw = new System.IO.FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //缓存
                    byte[] buff = new byte[BufferSize];

                    StringBuilder sb = new StringBuilder(content);

                    int bufLenght = Convert.ToBase64String(buff).Length;
                    int startindex = 0;

                    //大于缓存数组大小的时候
                    while (sb.Length - startindex >= bufLenght)
                    {
                        buff = Convert.FromBase64String(sb.ToString(startindex, bufLenght));
                        //写入流
                        sw.Write(buff, 0, buff.Length);
                        startindex += bufLenght;
                    }

                    //小于缓存数组的时候
                    if (sb.Length - startindex > 0)
                    {
                        buff = Convert.FromBase64String(sb.ToString(startindex, sb.Length - startindex));
                        sw.Write(buff, 0, buff.Length);
                    }

                    sw.Close();
                }

                return new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Delete);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region 得到当前文件夹及下级文件夹中所有文件列表
        /// <summary>
        /// 得到当前文件夹及下级文件夹中所有文件列表
        /// </summary>
        /// <param name="DirFullPath">文件夹全路径</param>
        /// <returns>string[] 文件列表</returns>
        public static string[] GetAllDirAndFiles(string DirFullPath)
        {
            if (Directory.Exists(DirFullPath) == true)
            {
                string[] s = Directory.GetFileSystemEntries(DirFullPath, "*.*", SearchOption.AllDirectories); //获取当前目录下的所有文件(包含子文件夹中的文件)
                return s;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 操作选项
        /// <summary>
        /// 创建文件夹时的操作选项
        /// </summary>
        public enum OperateOption
        {
            /// <summary>
            /// 当被创建的文件夹存在时，先删除该文件夹
            /// </summary>
            ExistDelete,

            /// <summary>
            /// 当文件夹存在时，直接返回，不进行其它操作
            /// </summary>
            ExistReturn
        }
        #endregion

        #region 创建文件夹
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="DirFullPath">要创建的文件夹全路径</param>
        /// <param name="Option">创建文件夹时的操作选项</param>
        /// <returns>bool 是否创建成功</returns>
        public static bool CreateDir(string DirFullPath, OperateOption Option)
        {
            try
            {
                if (Directory.Exists(DirFullPath) == false) //判断文件夹是否存在
                {
                    Directory.CreateDirectory(DirFullPath);
                }
                else if (Option == OperateOption.ExistDelete) //如果存在且选项为“存在删除”
                {
                    Directory.Delete(DirFullPath); //删除目录，并删除此目录下的所以子目录
                    Directory.CreateDirectory(DirFullPath); //创建目录
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 删除文件夹
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="DirFullPath"></param>
        /// <returns></returns>
        public static bool DeleteDir(string DirFullPath)
        {
            if (Directory.Exists(DirFullPath) == true)
            {
                Directory.Delete(DirFullPath, true);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 得到当前文件夹中所有文件列表
        /// <summary>
        /// 得到当前文件夹中所有文件列表
        /// </summary>
        /// <param name="DirFullPath">文件夹全路径</param>
        /// <returns>string[] 文件列表</returns>
        public static string[] GetFiles(string DirFullPath)
        {
            if (Directory.Exists(DirFullPath) == true)
            {
                string[] s = Directory.GetFiles(DirFullPath, "*.*", SearchOption.TopDirectoryOnly); //获取当前目录下的所有文件
                return s;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 得到当前文件夹及下级文件夹中所有文件列表
        /// <summary>
        /// 得到当前文件夹及下级文件夹中所有文件列表
        /// </summary>
        /// <param name="DirFullPath">文件夹全路径</param>
        /// <returns>string[] 文件列表</returns>
        public static string[] GetAllFiles(string DirFullPath)
        {
            if (Directory.Exists(DirFullPath) == true)
            {
                string[] s = Directory.GetFiles(DirFullPath, "*.*", SearchOption.AllDirectories); //获取当前目录下的所有文件(包含子文件夹中的文件)
                return s;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 得到当前文件夹中指定文件类型［扩展名］文件列表
        /// <summary>
        /// 得到当前文件夹中指定文件类型［扩展名］文件列表
        /// </summary>
        /// <param name="DirFullPath">文件夹的全路径</param>
        /// <param name="SearchPattern">查找哪种类型的文件</param>
        /// <returns>string[] 文件列表</returns>
        public static string[] GetPatternFiles(string DirFullPath, string SearchPattern)
        {
            if (Directory.Exists(DirFullPath) == true)
            {
                string[] s = Directory.GetFiles(DirFullPath, SearchPattern); //获取当前目录下指定文件类型的文件列表
                return s;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 得到当前文件夹及下级文件夹中指定文件类型［扩展名］文件列表
        /// <summary>
        /// 得到当前文件夹及下级文件夹中指定文件类型［扩展名］文件列表
        /// </summary>
        /// <param name="DirFullPath">目录全路径</param>
        /// <param name="SearchPattern">查找哪种类型的文件</param>
        /// <returns>string[] 文件列表</returns>
        public static string[] GetAllPatternFiles(string DirFullPath, string SearchPattern)
        {
            if (Directory.Exists(DirFullPath) == true)
            {
                string[] s = Directory.GetFiles(DirFullPath, SearchPattern, SearchOption.AllDirectories); //获取当前目录下的文件
                return s;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 得到当前文件夹中所有文件列表
        /// <summary>
        /// 得到当前文件夹中所有文件列表
        /// </summary>
        /// <param name="DirFullPath">文件夹全路径</param>
        /// <returns>string[] 文件列表</returns>
        public static string[] GetDirAndFiles(string DirFullPath)
        {
            if (Directory.Exists(DirFullPath) == true)
            {
                string[] s = Directory.GetFileSystemEntries(DirFullPath, "*.*", SearchOption.TopDirectoryOnly); //获取当前目录下的所有文件
                return s;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 复制源文件夹到目标文件夹
        /// <summary>
        /// 拷贝文件夹
        /// </summary>
        /// <param name="srcdir">原文件夹</param>
        /// <param name="desdir">目的文件夹</param>
        public static void CopyDirectory(string srcdir, string desdir)
        {
            string folderName = srcdir.Substring(srcdir.LastIndexOf("\\", System.StringComparison.Ordinal) + 1);
            string desfolderdir = desdir + "\\" + folderName;

            //如果源路径是一个文件，则直接拷贝文件
            if (!Directory.Exists(srcdir) && File.Exists(srcdir))
            {
                File.Copy(srcdir, desfolderdir, true);
                return;
            }

            if (desdir.LastIndexOf("\\", System.StringComparison.Ordinal) == (desdir.Length - 1))
            {
                desfolderdir = desdir + folderName;
            }
            string[] filenames = Directory.GetFileSystemEntries(srcdir);

            foreach (string file in filenames) // 遍历所有的文件和目录
            {
                if (Directory.Exists(file)) // 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                {

                    string currentdir = desfolderdir + "\\" + file.Substring(file.LastIndexOf("\\", System.StringComparison.Ordinal) + 1);
                    if (!Directory.Exists(currentdir))
                    {
                        Directory.CreateDirectory(currentdir);
                    }

                    CopyDirectory(file, desfolderdir);
                }
                else // 否则直接copy文件
                {
                    string srcfileName = file.Substring(file.LastIndexOf("\\", System.StringComparison.Ordinal) + 1);

                    srcfileName = desfolderdir + "\\" + srcfileName;

                    if (!Directory.Exists(desfolderdir))
                    {
                        Directory.CreateDirectory(desfolderdir);
                    }

                    File.Copy(file, srcfileName, true);
                }
            }
        } 
        #endregion

        #region 移动源文件夹到目标文件夹
        /// <summary>
        /// 移动源文件夹到目标文件夹
        /// </summary>
        /// <param name="srcdir">源文件夹</param>
        /// <param name="desdir">目标文件夹</param>
        /// <returns></returns>
        public static bool MoveDirectory(string srcdir, string desdir)
        {
            CopyDirectory(srcdir, desdir);
            return DeleteDir(srcdir);
        } 
        #endregion
    }
}