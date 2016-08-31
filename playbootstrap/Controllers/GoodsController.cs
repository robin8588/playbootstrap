using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using playbootstrap.Models;

namespace playbootstrap.Controllers
{
    public class GoodsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Goods
        public ActionResult Index(int page=0)
        {
            return View(new PageList<Goods>(db.Goods.OrderByDescending(v=>v.GoodsName), page, 10));
        }

        // GET: Goods/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = await db.Goods.FindAsync(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GoodsId,GoodsName,Thumbnail,BannerUrl,Description,GoodsKind,GoodsBreed,GoodsProduce,GoodsGrade,GoodsLabels,GoodsCode,Price,OriginalPrice,PriceUnit,OrderUnit")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                goods.GoodsId = Guid.NewGuid();
                db.Goods.Add(goods);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(goods);
        }

        // GET: Goods/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = await db.Goods.FindAsync(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // POST: Goods/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GoodsId,GoodsName,Thumbnail,BannerUrl,Description,GoodsKind,GoodsBreed,GoodsProduce,GoodsGrade,GoodsLabels,GoodsCode,Price,OriginalPrice,PriceUnit,OrderUnit")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goods).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(goods);
        }

        // GET: Goods/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = await db.Goods.FindAsync(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Goods goods = await db.Goods.FindAsync(id);
            db.Goods.Remove(goods);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
