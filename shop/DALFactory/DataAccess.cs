using System.Reflection;
using System.Configuration;

namespace DALFactory
{
    public sealed class DataAccess
    {
        //DAL命名空间
        private static readonly string DALPath = ConfigurationManager.AppSettings["DALPath"];
        /// <summary>
        /// 私有构造函数
        /// </summary>
        private DataAccess() { }
        /// <summary>
        /// 分类
        /// </summary>
        /// <returns></returns>
        public static IDAL.ICategory CreateCategory()
        {
            string className =DALPath+ ".Category";
            return (IDAL.ICategory)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 调拨
        /// </summary>
        /// <returns></returns>
        public static IDAL.IChangeStock CreateChangeStock()
        {
            string className = DALPath + ".ChangeStock";
            return (IDAL.IChangeStock)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 调拨类型
        /// </summary>
        /// <returns></returns>
        public static IDAL.IChangeType CreateChangeType()
        {
            string className = DALPath + ".ChangeType";
            return (IDAL.IChangeType)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 盘点单
        /// </summary>
        /// <returns></returns>
        public static IDAL.ICheckBill CreateCheckBill()
        {
            string className = DALPath + ".CheckBill";
            return (IDAL.ICheckBill)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 颜色
        /// </summary>
        /// <returns></returns>
        public static IDAL.IColors CreateColors()
        {
            string className = DALPath + ".Colors";
            return (IDAL.IColors)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 商品
        /// </summary>
        /// <returns></returns>
        public static IDAL.IProduct CreateProduct()
        {
            string className = DALPath + ".Product";
            return (IDAL.IProduct)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 采购单
        /// </summary>
        /// <returns></returns>
        public static IDAL.IProductBill CreateProductBill()
        {
            string className = DALPath + ".ProductBill";
            return (IDAL.IProductBill)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 销售单
        /// </summary>
        /// <returns></returns>
        public static IDAL.ISailBill CreateSailBill()
        {
            string className = DALPath + ".SailBill";
            return (IDAL.ISailBill)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 库存
        /// </summary>
        /// <returns></returns>
        public static IDAL.IStock CreateStock()
        {
            string className = DALPath + ".Stock";
            return (IDAL.IStock)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 库存备份
        /// </summary>
        /// <returns></returns>
        public static IDAL.IStockBackUp CreateStockBackUp()
        {
            string className = DALPath + ".StockBackUp";
            return (IDAL.IStockBackUp)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 入库
        /// </summary>
        /// <returns></returns>
        public static IDAL.IStockIn CreateStockIn()
        {
            string className = DALPath + ".StockIn";
            return (IDAL.IStockIn)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 出库
        /// </summary>
        /// <returns></returns>
        public static IDAL.IStockOut CreateStockOut()
        {
            string className = DALPath + ".StockOut";
            return (IDAL.IStockOut)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 员工
        /// </summary>
        /// <returns></returns>
        public static IDAL.IStuff CreateStuff()
        {
            string className = DALPath + ".Stuff";
            return (IDAL.IStuff)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 供应商
        /// </summary>
        /// <returns></returns>
        public static IDAL.ISupplier CreateSupplier()
        {
            string className = DALPath + ".Supplier";
            return (IDAL.ISupplier)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 型号
        /// </summary>
        /// <returns></returns>
        public static IDAL.ITypes CreateTypes()
        {
            string className = DALPath + ".Types";
            return (IDAL.ITypes)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 单位
        /// </summary>
        /// <returns></returns>
        public static IDAL.IUnits CreateUnits()
        {
            string className = DALPath + ".Units";
            return (IDAL.IUnits)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 用户
        /// </summary>
        /// <returns></returns>
        public static IDAL.IUser CreateUser()
        {
            string className = DALPath + ".User";
            return (IDAL.IUser)Assembly.Load(DALPath).CreateInstance(className);
        }
        /// <summary>
        /// 仓库
        /// </summary>
        /// <returns></returns>
        public static IDAL.IWareHouse CreateWareHouse()
        {
            string className = DALPath + ".WareHouse";
            return (IDAL.IWareHouse)Assembly.Load(DALPath).CreateInstance(className);
        }
    }
}
