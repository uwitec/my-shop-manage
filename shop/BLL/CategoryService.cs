using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBLL;
using Common;
using IDAL;
using System.Data.SqlClient;
using DBUtility;
using Model;

namespace BLL
{
    public class CategoryService :ICategoryService
    {
        private ICategory categoryDal = DALFactory.DataAccess.CreateCategory();
        public int GetCategoryCount(IEnumerable<SearchCondition> condition)
        {
            SqlConnection conn;
            int count=0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                count=categoryDal.GetCategoryCount(condition,conn);
                conn.Close();
            }
            return count;
        }
        public int DeleteCategory(Guid categoryId)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                count = categoryDal.DeleteCategoryById(categoryId,conn);
                conn.Close();
            }
            return count;
        }

        public int UpdateCategory(CategoryInfo category)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                count = categoryDal.UpdateCategory(category,conn);
                conn.Close();
            }
            return count;
        }

        public int InsertCategory(CategoryInfo category)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                count = categoryDal.InsertCategory(category, conn);
                conn.Close();
            }
            return count;
        }

        public CategoryInfo GetCategoryById(Guid categoryId)
        {
            SqlConnection conn;
            IList<CategoryInfo> category;
            SearchCondition[] condition = new SearchCondition[] { new SearchCondition{con="id=@id",param="@id",value=categoryId.ToString()}};
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                category = categoryDal.GetCategory(condition, conn);
                if(category.Count>0)
                {
                    return category[0];
                }
                conn.Close();
                return null;
            }
        }

        public IList<CategoryInfo> GetPageCategory(IEnumerable<SearchCondition> condition, int page, int pagesize)
        {
            SqlConnection conn;
            IList<CategoryInfo> category;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                category = categoryDal.GetPageCategory(condition,page,pagesize,conn);
                conn.Close();
                return category;
            }
        }

    }
}
