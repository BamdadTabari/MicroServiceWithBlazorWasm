using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illegible_Cms_V2.Shared.BasicShared.Configurations
{
    public class MinioConfig
    {
        public string Connection { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string RootBucketName { get; set; }
    }
}
