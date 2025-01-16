namespace CQRSNight.CQRSDesignPattern.Queries.CategoryQueries
{
    public class GetCategoryQuery
    {
        public int CategoryId { get; set; }

        public GetCategoryQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
