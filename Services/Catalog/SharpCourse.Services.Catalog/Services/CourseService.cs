using System;
using AutoMapper;
using Mass = MassTransit;
using MongoDB.Driver;
using Sharp.Shared.Dtos;
using SharpCourse.Services.Catalog.Dtos;
using SharpCourse.Services.Catalog.Models;
using SharpCourse.Services.Catalog.Settings;
using Sharp.Shared.Messages;

namespace SharpCourse.Services.Catalog.Services
{
	public class CourseService:ICourseService
	{
        private readonly IMongoCollection<Course> _courseCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        private readonly Mass.IPublishEndpoint _publishEndPoint;

        public CourseService(IMapper mapper, IDatabaseSettings databaseSettings, Mass.IPublishEndpoint publishEndPoint)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _courseCollection = database.GetCollection<Course>(databaseSettings.CourseCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

            _mapper = mapper;
            _publishEndPoint = publishEndPoint;
        }

        public async Task<Response<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _courseCollection.Find(course => true).ToListAsync();

            if(courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Course>();
            }

            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<Response<CourseDto>> GetByIdAsync(string Id)
        {
            var course = await _courseCollection.Find<Course>(x => x.Id == Id).FirstOrDefaultAsync();

            if(course == null)
            {
                return Response<CourseDto>.Fail("Course not found.", 404);
            }

            course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync();

            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);
        }

        public async Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId)
        {
            var courses = await _courseCollection.Find(x=> x.UserId == userId).ToListAsync();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Course>();
            }

            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto)
        {
            var newCourse = _mapper.Map<Course>(courseCreateDto);

            newCourse.CreatedTime = DateTime.Now;
            await _courseCollection.InsertOneAsync(newCourse);

            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(newCourse), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            var updateCourse = _mapper.Map<Course>(courseUpdateDto);

            updateCourse.UpdatedTime = DateTime.Now;
            var result = await _courseCollection.FindOneAndReplaceAsync(x => x.Id == courseUpdateDto.Id, updateCourse);

            if (result == null)
            {
                return Response<NoContent>.Fail("Course not found.", 404);
            }

            await _publishEndPoint.Publish<CourseNameChangedEvent>(new CourseNameChangedEvent
            { UserId = updateCourse.UserId,CourseId = updateCourse.Id, UpdatedName = courseUpdateDto.Name });

            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteAsync(string Id)
        {
            var result = await _courseCollection.DeleteOneAsync(x => x.Id == Id);

            if(result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Course not found.", 404);
            }
        }
    }
}

