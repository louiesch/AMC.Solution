using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AMC.Models;
using System.Collections.Generic;
using System.Linq;

namespace AMC.Controllers
{
  public class ActorsController : Controller
  {
    private readonly AMCContext _db;

    public ActorsController(AMCContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
        return View(_db.Actors.ToList());
    }
    public ActionResult Details(int id)
    {
      var thisActor = _db.Actors
        .Include(actor => actor.JoinEntities)
        .ThenInclude(join => join.Movie)
        .FirstOrDefault(actor => actor.ActorId == id);
    return View(thisActor);
    }

    public ActionResult Create()
    {
      ViewBag.MovieId = new SelectList(_db.Movies, "MovieId", "MovieName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Actor actor, int MovieId)
    {
      _db.Actors.Add(actor);
      _db.SaveChanges();
      if (MovieId != 0)
    {
        _db.MovieActor.Add(new MovieActor() { MovieId = MovieId, ActorId = actor.ActorId });
    }
    _db.SaveChanges();
      return RedirectToAction("Index");
    }


    public ActionResult Edit(int id)
    {
      var thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
      ViewBag.MovieId = new SelectList(_db.Movies, "MovieId", "MovieName");
      return View(thisActor);
    }

    [HttpPost]
    public ActionResult Edit(Actor actor, int MovieId)
    {
      if (MovieId != 0)
      {
        _db.MovieActor.Add(new MovieActor() { MovieId = MovieId, ActorId = actor.ActorId });
      }
      _db.Entry(actor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMovie(int id)
    {
      var thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
      ViewBag.MovieId = new SelectList(_db.Movies, "MovieId", "MovieName");
      return View(thisActor);
    }

    [HttpPost]
    public ActionResult AddMovie(Actor actor, int MovieId)
    {
        if (MovieId != 0)
        {
        _db.MovieActor.Add(new MovieActor() { MovieId = MovieId, ActorId = actor.ActorId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
      return View(thisActor);
    }

    [HttpPost]
    public ActionResult DeleteMovie(int joinId)
    {
        var joinEntry = _db.MovieActor.FirstOrDefault(entry => entry.MovieActorId == joinId);
        _db.MovieActor.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
      _db.Actors.Remove(thisActor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}