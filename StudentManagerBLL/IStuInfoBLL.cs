using StudentManagerModel;

namespace StudentManagerBLL
{
    public interface IStuInfoBLL
    {
   
        Task<bool> Create(AddStuInfo stuInfo);

        Task<PageSearchInfo> GetPageListData(int page = 1, int limit = 15, string userName = "");

        Task<bool> Update(StuInfo stuInfo);

        Task<bool> Delete(int id);

        Task<StuInfo> QueryStuInfoDetail(int id);
    }
}

