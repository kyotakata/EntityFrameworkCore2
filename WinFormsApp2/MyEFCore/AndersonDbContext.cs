using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.MyEFCore
{
    /// <summary>
    /// 接続したいデータベースの名前+DbContext
    /// AmazonならAmazonDbContext,TSUTAYAならTSUTAYADbContext
    /// システムの名前が入る
    /// </summary>
    public class AndersonDbContext : DbContext
    {
    }
}
