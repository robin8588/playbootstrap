using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace playbootstrap.Models
{
    // 可以通过向 ApplicationUser 类添加更多属性来为用户添加配置文件数据。若要了解详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=317594。
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在此处添加自定义用户声明
            return userIdentity;
        }
    }


    public class Order
    {
        public Guid OrderId { get; set; }

        public string OrderNumber { get; set; }
    }


    public class Goods
    {
        public Guid GoodsId { get; set; }
        [Display(Name ="产品名")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品图片路径(缩略图)
        /// </summary>
        [Display(Name = "缩略图")]
        public string Thumbnail { get; set; }
        /// <summary>
        /// 广告图
        /// </summary>
        [Display(Name = "广告图")]
        public string BannerUrl { get; set; }
        [Display(Name = "商品描述")]
        /// <summary>
        /// 商品描述，商品详情，商品详情信息（大字段）
        /// </summary>
        public string Description { get; set; }
        [Display(Name = "商品种类")]
        /// <summary>
        /// 商品种类(苹果，桃，梨，等）
        /// </summary>
        public string GoodsKind { get; set; }
        [Display(Name = "商品品种")]
        /// <summary>
        /// 商品品种
        /// </summary>
        public string GoodsBreed { get; set; }
        [Display(Name = "商品产地")]
        /// <summary>
        /// 商品产地
        /// </summary>

        public string GoodsProduce { get; set; }
        [Display(Name = "商品规格")]
        /// <summary>
        /// 商品规格(自己填)
        /// </summary>
        public string GoodsGrade { get; set; }
        [Display(Name = "商品标签")]
        /// <summary>
        /// 商品标签
        /// </summary>
        public string GoodsLabels { get; set; }
        [Display(Name = "商品编号")]
        /// <summary>
        /// 表示商品的编号
        /// </summary>
        public string GoodsCode { get; set; }
        [Display(Name = "折扣后价格")]

        /// <summary>
        /// 商品折扣后的价格
        /// </summary>
        //[Required]
        public decimal Price { get; set; }
        [Display(Name = "原始价格")]

        /// <summary>
        /// 商品的原始价格
        /// </summary>
        public decimal OriginalPrice { get; set; }
        [Display(Name = "定价单位")]

        /// <summary>
        /// 定价单位
        /// </summary>
        public string PriceUnit { get; set; }
        [Display(Name = "订货单位")]


        /// <summary>
        /// 订货单位
        /// </summary>
        public string OrderUnit { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Goods> Goods { get; set; }
    }
}