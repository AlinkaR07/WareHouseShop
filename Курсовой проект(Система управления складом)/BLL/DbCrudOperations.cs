using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using DAL.Models;

namespace BLL
{
    public class DbCrudOperations : IDbCrud
    {
        IDbReports db;

        public DbCrudOperations(IDbReports repos)
        {
            db = repos;
        }

        public TovarView GetTovar(int cod)
        {
            return new TovarView(db.tovar.GetItem(cod));
        }
        public TovarView GetTovar(string name)
        {
            return new TovarView(db.tovar.GetItem(name));
        }
        public OrderView GetOrder(int cod)
        {
            return new OrderView(db.order.GetItem(cod));
        }

        public List<TovarView> GetAllTovar()
        {
            return db.tovar.GetList().Select(i => new TovarView(i)).ToList();
        }
        public List<PostavshikView> GetAllPostavshiki()
        {
            return db.postavshik.GetList().Select(i => new PostavshikView(i)).ToList();
        }

        public List<OrderView> GetAllOrder()
        {
            return db.order.GetList().Select(i => new OrderView(i)).ToList();
        }
        public List<WriteView> GetAllWrite()
        {
            return db.write.GetList().Select(i => new WriteView(i)).ToList();
        }

        public List<CategoriesView> GetAllCategories()
        {
            return db.categories.GetList().Select(i => new CategoriesView(i)).ToList();
        }

        public List<LineOrderView> GetAllLineOrder()
        {
            return db.lineOrder.GetList().Select(i => new LineOrderView(i)).ToList();
        }
        public void CreateTovar(TovarView t)
        {
            db.tovar.Create(new Tovar() { Name = t.Name, DateExpiration = (DateTime)t.DateExpiration, Category = t.Category, Price = t.Price });
            Save();
        }

        public void CreatePostavshik(PostavshikView t)
        {
            db.postavshik.Create(new Postavshik() { NameOrganization = t.NameOrganization, FIOdirector = t.FIOdirector, INN = t.INN, NumberAccount = t.NumberAccount });
            Save();
        }

        public void CreateOrder(OrderView o)
        {
            db.order.Create(new Order() {  DataOrder = (DateTime)o.DataOrder, DataShipment = o.DataShipment, StatusOrder = o.StatusOrder, NameOrganizationPostavshik_FK_ = o.NameOrganizationPostavshik_FK_, FIOworker_FK_ = o.FIOworker_FK_ });
            Save();
        }

        public void CreateLineOrder(LineOrderView lo)
        {
            db.lineOrder.Create(new LineOrder() { CountOrder=lo.CountOrder, PurchasePrice =  lo.PurchasePrice, CountShipment = lo.CountShipment, CodTovara_FK_ = lo.CodTovara_FK_, NumberOrder_FK_ = lo.NumberOrder_FK_, DataManuf = lo.DataManuf});
            Save();
        }

        public void CreateWrite(WriteView w)
        {
            db.write.Create(new Write() { DataWrite = w.DataWrite, FIOworker_FK_= w.FIOworker_FK_});
            Save();
        }

        public void CreateLineWrite(LineWriteView lw)
        {
            db.lineWrite.Create(new LineWrite() { CodTovara_FK_ = lw.CodTovara_FK_, Count = lw.Count, NumberActWrite_FK_= lw.NumberActWrite_FK_, Summa = lw.Summa});
            Save();
        }

        public void UpdateTovar(TovarView t)
        {
            Tovar tov = db.tovar.GetItem(t.CodTovara);
            tov.Name = t.Name;
            tov.Count = t.Count;
            tov.DateExpiration = (DateTime)t.DateExpiration;
            tov.Category = t.Category;
            tov.Price = t.Price;
            db.tovar.Update(tov);
            Save();
        }

        public void UpdatePostavshik(PostavshikView p)
        {
            Postavshik post = db.postavshik.GetItem(int.Parse(p.NameOrganization));
            post.NameOrganization = p.NameOrganization;
            post.FIOdirector = p.FIOdirector;
            post.INN = p.INN;
            post.NumberAccount = p.NumberAccount;
            db.postavshik.Update(post);
            Save();
        }

        public void UpdateOrder(OrderView o)
        {
            Order ord = db.order.GetItem(o.Number);
            ord.DataOrder = (DateTime)o.DataOrder;
            ord.DataShipment = o.DataShipment;
            ord.StatusOrder = o.StatusOrder;
            ord.NameOrganizationPostavshik_FK_ = o.NameOrganizationPostavshik_FK_;
            ord.FIOworker_FK_ = o.FIOworker_FK_;
            db.order.Update(ord);
            Save();
        }

        public void UpdateLineOrder(LineOrderView lo)
        {
            
            LineOrder lineOrder = db.lineOrder.GetItem(lo.ID);
            lineOrder.CountOrder = lo.CountOrder;
            lineOrder.CountShipment = lo.CountShipment;
            lineOrder.CodTovara_FK_ = lo.CodTovara_FK_;
            lineOrder.DataManuf = lo.DataManuf;
            lineOrder.NumberOrder_FK_ = lo.NumberOrder_FK_;
            db.lineOrder.Update(lineOrder);
            Save();
           
        }
        public void UpdateWrite(WriteView w)
        {
            Write wr = db.write.GetItem(w.NumberAct);
            wr.NumberAct = w.NumberAct;
            wr.DataWrite = w.DataWrite;
            wr.FIOworker_FK_ = w.FIOworker_FK_;
            db.write.Update(wr);
            Save();
        }

        public void UpdateLineWrite(LineWriteView lw)
        {
            LineWrite lineWrite = db.lineWrite.GetItem(lw.ID);
            lineWrite.NumberActWrite_FK_ = lw.NumberActWrite_FK_;
            lineWrite.Summa = lw.Summa;
            lineWrite.Count = lw.Count;
            db.lineWrite.Update(lineWrite);
            Save();
        }

        public void DeleteTovar(int cod)
        {
            if (db.tovar.GetItem(cod) != null)
            {
                db.tovar.Delete(cod);
                Save();
            }
        }
        public void DeleteOrder(int cod)
        {
            if (db.order.GetItem(cod) != null)
            {
                db.order.Delete(cod);
                Save();
            }
        }
        public void DeleteLineOrder(int cod)
        {
            if (db.lineOrder.GetItem(cod) != null)
            {
                db.lineOrder.Delete(cod);
                Save();
            }
        }

        public void DeletePostavshik(string cod)
        {
            if (db.postavshik.GetItem(cod) != null)
            {
                db.postavshik.Delete(cod);
                Save();
            }
        }
        public void DeleteWrite(int cod)
        {
            if (db.write.GetItem(cod) != null)
            {
                db.write.Delete(cod);
                Save();
            }
        }
        public void DeleteLineWrite(int cod)
        {
            if (db.lineWrite.GetItem(cod) != null)
            {
                db.lineWrite.Delete(cod);
                Save();
            }
        }
        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
