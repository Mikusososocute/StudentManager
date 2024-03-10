using StudentManagerDAL.Migrations;
using StudentManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentManagerBLL
{
    public class StuInfoBLL : IStuInfoBLL
    {
        private readonly StuInfoContext _stuInfoContext;

        public StuInfoBLL(StuInfoContext stuInfoContext)
        {
            _stuInfoContext = stuInfoContext;
        }
        public async Task<bool> Create(AddStuInfo addStuInfo)
        {
            try
            {
                var stuInfo = new StuInfo()
                {
                    UserName = addStuInfo.UserName,
                    Sex = addStuInfo.Sex,
                    Hobby = addStuInfo.Hobby,
                    Phone = addStuInfo.Phone,
                    Description = addStuInfo.Description
                };

                _stuInfoContext.StuInfos.Add(stuInfo);

                await _stuInfoContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<bool> Delete(int id)
        {
            try
            {
                var searchStuInfo = await _stuInfoContext.StuInfos.FindAsync(id);

                if (searchStuInfo == null)
                {
                    return false;
                }

                _stuInfoContext.StuInfos.Remove(searchStuInfo);
                await _stuInfoContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<PageSearchInfo> GetPageListData(int page = 1, int limit = 15, string userName = "")
        {
           
            try
            {
                List<StuInfo> listData;
                var totalCount = 0;
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    listData = await _stuInfoContext.StuInfos.Where(x => x.UserName.Contains(userName)).OrderByDescending(x => x.Id).Skip((page - 1) * limit).Take(limit).ToListAsync();
                    totalCount = _stuInfoContext.StuInfos
                        .Count(x => x.UserName.Contains(userName));
                }
                else
                {
                    listData = await _stuInfoContext.StuInfos.OrderByDescending(x => x.Id).Skip((page - 1) * limit).Take(limit).ToListAsync();
                    totalCount = _stuInfoContext.StuInfos.Count();
                }

                return new PageSearchInfo()
                {
                    ResultMsg = "success",
                    Code = 200,
                    TotalCount = totalCount,
                    DataList = listData
                };
            }
            catch (Exception e)
            {
                return new PageSearchInfo() { Code = 400, ResultMsg = e.Message };
            }
        }
    

        public async Task<StuInfo> QueryStuInfoDetail(int id)
        {
            return await _stuInfoContext.StuInfos.FindAsync(id);
        }


        public async Task<bool> Update(StuInfo stuInfo)
        {
            try
            {
                _stuInfoContext.StuInfos.Update(stuInfo);

                await _stuInfoContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
