using Microsoft.AspNetCore.Mvc;
using StudentManagerModel;
using StudentManagerBLL;

namespace StudentManagerUI.Controllers
{
    public class OperationApiController : Controller
    {
        private readonly IStuInfoBLL _stuInfoBLL;

        public OperationApiController(IStuInfoBLL stuInfoBLL)
        {
            _stuInfoBLL = stuInfoBLL;
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">显示条数</param>
        /// <param name="userName">用户姓名</param>
        /// <returns></returns>
        public async Task<IActionResult> GetStuInfo(int page = 1, int limit = 15, string userName = "")
        {
            var result = await _stuInfoBLL.GetPageListData(page, limit, userName);

            if (result.Code == 200)
            {
                return Json(new { code = 0, count = result.TotalCount, data = result.DataList });
            }
            else
            {
                return Json(new { code = 1, resultMsg = result.ResultMsg });
            }
        }


        /// <summary>
        /// 信息添加
        /// </summary>
        /// <param name="stuInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddStuInfo(/*[FromBody]*/AddStuInfo stuInfo)
        {
            var result = await _stuInfoBLL.Create(stuInfo);

            return Json(result ? new { code = 0, resultMsg = "添加成功" } : new { code = 1, resultMsg = "网络打瞌睡了！" });
        }


        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="stuInfo"></param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateStuInfo(StuInfo stuInfo)
        {
            var result = await _stuInfoBLL.Update(stuInfo);

            return Json(result ? new { code = 0, resultMsg = "更新成功" } : new { code = 1, resultMsg = "网络打瞌睡了！" });
        }

        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DataDelete(int id)
        {
            var result = await _stuInfoBLL.Delete(id);

            return Json(result ? new { code = 0, resultMsg = "删除成功" } : new { code = 1, resultMsg = "网络打瞌睡了！" });
        }

        /// <summary>
        /// 获取数据记录详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> QueryStuInfoDetail(int id)
        {
            var result = await _stuInfoBLL.QueryStuInfoDetail(id);

            return Json(result != null ? new { code = 0, resultMsg = "删除成功" } : new { code = 1, resultMsg = "网络打瞌睡了！" });
        }
    }
}
