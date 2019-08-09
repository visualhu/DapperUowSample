using Microsoft.Extensions.Options;

namespace Data.Context
{
    public class DapperDbContextOptions : IOptions<DapperDbContextOptions>
    {
        //public string Configuration { get; set; }
        public string DbName { get; set; }
        DapperDbContextOptions IOptions<DapperDbContextOptions>.Value
        {
            get { return this; }
        }
    }
}
