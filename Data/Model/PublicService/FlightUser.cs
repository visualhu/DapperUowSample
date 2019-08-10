using Dapper.Contrib.Extensions;
using Infrastructure.Data;
using System;

namespace Data.Model.PublicService
{
    [Serializable]
    [Table("order")]
    public class FlightUser : EntityBase
    {
        [Key]
        public long Id { get; set; }
        public long CustomerId { get; set; }
        //public long FUId { get; set; }
        /////<summary>同一权限用户ID,long0</summary>
        //public long FUAuthorityId { get; set; }
        /////<summary>OA用户ID,long0</summary>
        //public long FUOaId { get; set; }
        /////<summary>姓名,string20</summary>
        //public string FUName { get; set; }
        /////<summary>工号,string20</summary>
        //public string FUJobNum { get; set; }
        /////<summary>工号-7位数,string20</summary>
        //public string FUWorkId { get; set; }
        /////<summary>性别,int0</summary>
        //public int FUGender { get; set; }
        /////<summary>部门名称,string20</summary>
        //public string FUDeptName { get; set; }
        /////<summary>是否在职,int0</summary>
        //public int FUEnable { get; set; }
        /////<summary>是否虚拟0-真实 1-虚拟,int0</summary>
        //public int FUIsvirtual { get; set; }
        /////<summary>手机号,string20</summary>
        //public string FUMobile { get; set; }
        /////<summary>邮箱,string50</summary>
        //public string FUEmail { get; set; }
        /////<summary>员工职位,string50</summary>
        //public string FUPosition { get; set; }
        /////<summary>统一权限部门Id,long0</summary>
        //public long FUDeptId { get; set; }
        /////<summary>oa部门Id,long0</summary>
        //public long FUOaDeptId { get; set; }
        /////<summary>OA部门父级ID,long0</summary>
        //public long FUOaDeptPid { get; set; }
        /////<summary>OA部门名称,string50</summary>
        //public string FUOaDeptName { get; set; }
        /////<summary>企业QQ号码，非常坑,string15</summary>
        //public string FUHrtxNum { get; set; }
        /////<summary>企业QQ名称，没有工号就用名称调取企业请求接口,string15</summary>
        //public string FUHrtxName { get; set; }
        /////<summary>头像图片地址,string200</summary>
        //public string FUPictureUrl { get; set; }
        /////<summary>记录状态,int0</summary>
        //public int FURecordStatus { get; set; }
        /////<summary>数据有效性字段,int0</summary>
        //public int FUDataFlag { get; set; }
        /////<summary>记录创建时间,DateTime0</summary>
        //public DateTime FUCreateTime { get; set; }
        /////<summary>更新时间,DateTime0</summary>
        //public DateTime FUUpdateTime { get; set; }
        /////<summary>微信号,string50</summary>
        //public string FUWeiXin { get; set; }
        /////<summary>企业微信ID,string50</summary>
        //public string FUWeWorkId { get; set; }
    }
}
