
using CandidateManagemente.Application.DTO;
using CandidateManagemente.Domain.Entities;
using CandidateManagemente.Domain.Interface;
using CandidateManagemente.Domain.Response;
using CandidateManagemente.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CandidateManagemente.Infra.Data.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly DbContextOptions<MyCustomDbContext> _context;
        public CandidateRepository()
        {
            _context = new DbContextOptions<MyCustomDbContext>();
        }
        public List<Candidates> GetAll()
        {
            using (var date = new MyCustomDbContext(_context))
            {
                return date.Set<Candidates>().AsNoTracking().ToList();
            }
        }
        public List<OCandidateExperiences> GetId(int id)
        {
            using (var date = new MyCustomDbContext(_context))
            {
                var query = from c in date.Candidates
                            join exp in date.Experiences on c.IdCandidate equals exp.IdCandidate
                            where c.IdCandidate.Equals(id)
                            select new OCandidateExperiences
                            {
                                IdCandidate = c.IdCandidate,
                                Name = c.Name,
                                Surname = c.Surname,
                                BirthDate = c.BirthDate,
                                Email = c.Email,
                                Company = exp.Company,
                                Job = exp.Job,
                                Description = exp.Description,
                                Salary = exp.Salary,
                                BeginDate = exp.BeginDate,
                                EndDate = exp.EndDate
                            };
                return query.ToList();
            }
        }

        public int AddCandidate(Candidates Cand)
        {
            using (var date = new MyCustomDbContext(_context))
            {

                date.Set<Candidates>().Add(Cand);
                date.SaveChanges();
                return Cand.IdCandidate;
            }
        }
        public Task AddExperience(Experiences ExpCand)
        {
            using (var date = new MyCustomDbContext(_context))
            {

                date.Set<Experiences>().Add(ExpCand);
                date.SaveChanges();
                return Task.CompletedTask;
            }
        }
        public string Update(OCandidateExperiences obj)
        {
            using (var date = new MyCustomDbContext(_context))
            {
                try
                {
                    var tbCandidateExperience = from c in date.Candidates
                                                join exp in date.Experiences on c.IdCandidate equals exp.IdCandidate
                                                where c.IdCandidate.Equals(exp.IdCandidate)
                                                select new { exp.IdCandidateExperience, exp.InsertDate };

                    var dbCand = new Candidates
                    {
                        IdCandidate = obj.IdCandidate,
                        BirthDate = DateTime.Now,
                        Email = obj.Email,
                        Name = obj.Name,
                        Surname = obj.Surname,
                        ModifyDate = DateTime.Now,
                        InsertDate = tbCandidateExperience.Select(x => x.InsertDate).FirstOrDefault()

                    };

                    var dbExp = new Experiences
                    {
                        IdCandidate = obj.IdCandidate,
                        Company = obj.Company,
                        Job = obj.Job,
                        Description = obj.Description,
                        Salary = obj.Salary,
                        BeginDate = obj.BirthDate,
                        EndDate = obj.EndDate,
                        ModifyDate = DateTime.Now,
                        InsertDate = tbCandidateExperience.Select(x => x.InsertDate).FirstOrDefault()
                    };


                    dbExp.IdCandidateExperience = tbCandidateExperience.Select(x => x.IdCandidateExperience).FirstOrDefault();

                    date.Set<Candidates>().Update(dbCand);
                    date.Set<Experiences>().Update(dbExp);
                    date.SaveChanges();
                    return "Saved successfully";
                }
                catch (System.Exception ex)
                {
                    return "Error saving candidate";
                    throw;
                }
            }

        }
        public string Delete(int Id)
        {
            using (var date = new MyCustomDbContext(_context))
            {
                var notification = "";
                var candidate = date.Candidates.FirstOrDefault(p => p.IdCandidate == Id);
                var experience = date.Experiences.FirstOrDefault(p => p.IdCandidate == Id);
                if (candidate != null && experience != null)
                {
                    date.Set<Candidates>().Remove(candidate);
                    date.Set<Experiences>().Remove(experience);
                    date.SaveChanges();
                    notification = "Candidate successfully deleted.";
                }
                else
                {
                    notification = "Error deleting candidate, please try again.";
                }
                return notification;
            }
        }

    }
}
