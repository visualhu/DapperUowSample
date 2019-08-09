using Dapper.Contrib.Extensions;
using System;

namespace Data.Model.Sentry
{
    [Table("SysMenu")]
    public class SysMenu : EntityBase
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string ParentId { get; set; } = Guid.Empty.ToString();
        /// <summary>
        /// 可操作清单
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 已分配的操作
        /// </summary>
        [Computed]
        public string AssignedAction { get; set; }
        public int Sort { get; set; }
        /// <summary>
        /// 菜单状态，1有效，0无效
        /// </summary>
        public int Status { get; set; }

    }
}
