
using Data;
using Interfaces;
using Models;

namespace Repo;

public class UnitOfWork : IUnitOfWork
{
    private readonly VizeetaAppDbContext _context;

    public UnitOfWork(VizeetaAppDbContext context)
    {
        _context = context;
        Appointments = new Repository<Appointment>(_context);
        Doctors = new Repository<Doctor>(_context);
        Patients = new Repository<Patient>(_context);
        Genders = new Repository<Gender>(_context);
       
        Reviews = new Repository<Review>(_context);
        Specializations = new Repository<Specialization>(_context);
        Cities = new Repository<City>(_context);
    }
    public IRepository<Appointment> Appointments { get; }
    public IRepository<Doctor> Doctors { get; }
    public IRepository<Patient> Patients { get; }
    public IRepository<Gender> Genders { get; }
    public IRepository<Review> Reviews { get; }
    public IRepository<Specialization> Specializations { get; }
    public IRepository<City> Cities { get; }

    public void Dispose()
    {
        _context.Dispose();
    }

    public int Save()
    {
        return _context.SaveChanges();
    }
}
