using ApplicationLogics.Repository;

namespace ApplicationLogics
{
    public class Program
    {

        /// <summary>
        /// Set context, e.g. local database or flatfile
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            /* Dependency injection: 
            // Set context 
            var context = new LocalContext();
            // Inject context into db repository 
            var repository = new DbRepository<Study>(context);
            // Setup client 
            var studyStock = new Stock(repository); // Fictive class 
            */
        }

        /*
        public class StudyStock
        {
            public IRepository<Study> _studies;

            public StudyStock(IRepository<Study> db)
            {
                _studies = db;
            }
        }
        */

    }

}
