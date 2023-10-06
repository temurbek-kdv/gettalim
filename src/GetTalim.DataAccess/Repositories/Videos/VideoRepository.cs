using Dapper;
using GetTalim.DataAccess.Interfaces.Videos;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Videos;
using static Dapper.SqlMapper;

namespace GetTalim.DataAccess.Repositories.Videos;

public class VideoRepository : BaseRepository, IVideoRepository
{
    public async Task<int> CreateAsync(Video entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO videos(name, video_path, length, course_modul_id, created_at, updated_at) " +
                " VALUES (@Name, @VideoPath, @Length, @CourseModulId, @CreatedAt, @UpdatedAt) ; ";

            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM videos WHERE id = @Id ";

            var result = await _connection.ExecuteAsync(query, new { Id = id });
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Video>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM videos order by id desc";

            var result = (await _connection.QueryAsync<Video>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Video>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public async Task<Video?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM videos WHERE id = @Id";

            var result = await _connection.QuerySingleAsync<Video>(query, new { Id = id });
            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Video entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE videos SET name=@Name, " +
                " video_path=@VideoPath, length=@Length, course_modul_id=@CourseModulId, " +
                $" created_at=@CreatedAt, updated_at=@UpdatedAt WHERE id = {id};";
                
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT count(*) FROM videos";

            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Video>> GetVideoByModuleIdAsync(long moduleId)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM videos WHERE course_modul_id = {moduleId}";

            var result = await _connection.QueryAsync<Video>(query);
            
            return result.ToList();
        }
        catch
        {
            return new List<Video>();   
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<VideoWithoutPath>> GetVideoForCommonAsync(long moduleId)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT id, name, length, course_modul_id, created_at, updated_at " +
                $" FROM videos WHERE course_modul_id = {moduleId}";

            var result = await _connection.QueryAsync<VideoWithoutPath>(query);

            return result.ToList();
        }
        catch
        {
            return new List<VideoWithoutPath>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
