using System.Linq.Expressions;

namespace WEB_053504_Mazurenko.Models
{
    public class ListViewModel<T> : List<T>
    {
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public List<T> Objects { get; set; }

        private ListViewModel()
        {

        }

        public static ListViewModel<T> GetModel(IQueryable<T> list, int currentPage, int itemsPerPage, Expression<Func<T, bool>> filter)
        {
            return new ListViewModel<T>
            {
                Objects = list.Where(filter).Skip((currentPage - 1) * itemsPerPage).Take(itemsPerPage).ToList(),
                CurrentPage = currentPage,
                PagesCount = (int)(list.Count() / itemsPerPage)
            };
        }
    }
}
