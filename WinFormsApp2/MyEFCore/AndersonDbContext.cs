using Microsoft.Data.SqlClient;
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
        /// <summary>
        /// DbSet<TEntity>を介してデータベースにアクセスし、Productデータを全件取得する
        /// プロパティ名はテーブルの名前を指定する
        /// </summary>
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 接続先情報定義
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"DESKTOP-O4DS0L0";
            builder.InitialCatalog = "AndersonA";
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;

            //UseSqlServerで接続先を指定
            optionsBuilder.UseSqlServer(builder.ConnectionString);
        }
    }

    /// <summary>
    /// モデルクラス
    /// </summary>
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }// varchar(255)はC#でいうところのstring
        public int Price { get; set; }

    }
}
