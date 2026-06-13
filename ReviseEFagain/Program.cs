using Microsoft.EntityFrameworkCore;
using ReviseEFagain.Data;
using ReviseEFagain.Entity;

AppDbContext db = new AppDbContext();


//Movie movie1 = new Movie()
//{
//    Title = "KGF",
//    ReleaseYear = 2018,
//    Rating = 9
//};

//db.Movies.Add(movie1);

//db.SaveChanges();

//------------------------------------------
//Movie m4 = new Movie()
//{
//    Title = "KGF",
//    ReleaseYear = 2023,
//    Rating = 6
//};

//Movie m2 = new Movie()
//{
//    Title = "Pushpa",
//    ReleaseYear = 2021,
//    Rating = 8
//};

//Movie m3 = new Movie()
//{
//    Title = "Animal",
//    ReleaseYear = 2023,
//    Rating = 8
//};

//db.Movies.AddRange(m4, m2, m3);

//db.SaveChanges();

//Console.WriteLine("Movie Added");
//---------------------------------------------

//Read
//1. ToList
var movies = db.Movies.ToList();
foreach(var movie in movies)
{
    Console.WriteLine(
   $"{movie.Id} {movie.Title} {movie.ReleaseYear}"   );
}
Console.WriteLine("---------------------------------------");
//2.Find
var movie1 = db.Movies.Find(1);
if(movie1 != null)
{
    Console.WriteLine(
   $"{movie1.Id} {movie1.Title} {movie1.ReleaseYear}");
}
Console.WriteLine("---------------------------------------");
//3.FirstOrDefault
var movie2 = db.Movies.FirstOrDefault(x => x.Title == "KGF");
if (movie2 != null)
{
    Console.WriteLine($"{movie2.Title}");
}
Console.WriteLine("---------------------------------------");
//4 First
//var movie3 = db.Movies.First(x => x.Title == "KGF");
//if (movie2 != null)
//{
//    Console.WriteLine($"{movie3.Title}");
//}
Console.WriteLine("---------------------------------------");
//5.Single
var count = db.Movies.Count(x => x.Title == "Pushpa");

if (count == 1)
{
    var movie4 = db.Movies.Single(x => x.Title == "Pushpa");
    Console.WriteLine(
       $"{movie4.Id} {movie4.Title} {movie4.ReleaseYear}"
   );
}
else if (count == 0)
{
    Console.WriteLine("Movie not found");
}
else
{
    Console.WriteLine("Duplicate records found");
}
Console.WriteLine("---------------------------------------");
//6.SingleorDefault
var movie6 = db.Movies.SingleOrDefault(x => x.Title == "Pushpa");
if (movie6 != null)
{
    Console.WriteLine($"{movie6.Id} {movie6.Title} {movie6.ReleaseYear}");
}
else
{
    Console.WriteLine("Movie not found");
}
Console.WriteLine("---------------------------------------");
//--------Update-----
var movieUpdate = db.Movies.Find(2);

if (movieUpdate != null)
{
    movieUpdate.Title = "KGF Chapter 2";
    db.SaveChanges();
}
Console.WriteLine("---------------------------------------");

//--------------Delete--------------
//var movie =
//db.Movies.Find(1);

//if (movie != null)
//{
//    db.Movies.Remove(movie);

//    db.SaveChanges();
//}
Console.WriteLine("---------------------------------------");
//Linq with Ef
//1.Where
var movie10 = db.Movies.Where(x => x.Rating > 7);
foreach(var list in movie10)
{
    Console.Write(list.Title);
}
Console.WriteLine("---------------------------------------");
//2.OrderBy & OrderByDescending
var movie11 = db.Movies.OrderBy(x => x.Rating);
var movie12 = db.Movies.OrderByDescending(x => x.Rating);
foreach(var item in movie11)
{
    Console.WriteLine($"{item.Title}{item.Rating}");
}
foreach (var item in movie12)
{
    Console.WriteLine($"{item.Title}{item.Rating}");
}
Console.WriteLine("---------------------------------------");
//3.Select
var movie13 = db.Movies.Select(x => x.Title);
foreach (var item in movie13)
{
    Console.WriteLine(item);
}
Console.WriteLine("---------------------------------------");

//4. Count
var total =db.Movies.Count();
Console.WriteLine(total);
Console.WriteLine("---------------------------------------");
//5.Any
var movie14 =db.Movies.Any(x => x.Title == "KGF");
Console.WriteLine(movie14);
Console.WriteLine("---------------------------------------");
//6. All
var movie15 = db.Movies.All(x => x.Title == "Pushpa");
Console.WriteLine(movie15);
Console.WriteLine("---------------------------------------");
//Min
var minRating =
db.Movies.Min(x => x.Rating);

Console.WriteLine(minRating);
Console.WriteLine("---------------------------------------");

//Max
var maxRating =
db.Movies.Max(x => x.Rating);

Console.WriteLine(maxRating);
Console.WriteLine("---------------------------------------");

//Sum
var SumRating =
db.Movies.Sum(x => x.Rating);

Console.WriteLine(SumRating);

Console.WriteLine("---------------------------------------");
//Take
var moviesTake =
db.Movies.Take(2);

foreach (var item in moviesTake)
{
    Console.WriteLine(item.Title);
}
Console.WriteLine("---------------------------------------");
//Skip
var Skippedmovies =
db.Movies.Skip(2);

foreach (var item in Skippedmovies)
{
    Console.WriteLine(item.Title);
}
Console.WriteLine("---------------------------------------");
//Distinct
var years =db.Movies.Select(x => x.ReleaseYear).Distinct();
foreach (var item in years)
{
    Console.WriteLine(item);
}
Console.WriteLine("---------------------------------------");

//Review r1 = new Review()
//{
//    Comment = "Amazing",
//    MovieId = 1
//};

//Review r2 = new Review()
//{
//    Comment = "Blockbuster",
//    MovieId = 1
//};

//db.Reviews.AddRange(r1, r2);

//db.SaveChanges();
var movie16 = db.Movies
              .Include(x => x.Reviews)
              .FirstOrDefault(x => x.Id == 1);

if(movie16 != null)
{
    Console.WriteLine($"Movie : {movie16.Title}");

    foreach(var review in movie16.Reviews)
    {
        Console.WriteLine(review.Comment);
    }
}
Console.WriteLine("-------------------------------------------------------");
//MovieDetail detail = new MovieDetail()
//{
//    Director = "Prashanth Neel",
//    Budget = 80,
//    MovieId = 1
//};

//db.MovieDetails.Add(detail);

//db.SaveChanges();

//Console.WriteLine("Movie Detail Added");
Console.WriteLine("-------------------------------------------------------");
var movie17 = db.Movies
    .Include(x => x.MovieDetail)
    .FirstOrDefault(x => x.Id == 1);

if (movie17 != null)
{
    Console.WriteLine(movie17.Title);

    Console.WriteLine( movie17.MovieDetail.Director );

    Console.WriteLine(  movie17.MovieDetail.Budget );
}





//namespace ReviseEFagain
//{
//    internal class ReviseChangeTracker
//    {
//        public ReviseChangeTracker()
//        {
//            AppDbContext db = new AppDbContext();

//            //-------------------------------------------
//            // 1. Detached State
//            //-------------------------------------------

//            Movie movie1 = new Movie()
//            {
//                Title = "Demo Movie",
//                ReleaseYear = 2025,
//                Rating = 8
//            };

//            Console.WriteLine("Detached State");
//            Console.WriteLine(
//                db.Entry(movie1).State
//            );

//            //-------------------------------------------
//            // 2. Added State
//            //-------------------------------------------

//            db.Movies.Add(movie1);

//            Console.WriteLine("\nAdded State");
//            Console.WriteLine(
//                db.Entry(movie1).State
//            );

//            //-------------------------------------------
//            // 3. SaveChanges()
//            //-------------------------------------------

//            db.SaveChanges();

//            Console.WriteLine("\nAfter SaveChanges()");
//            Console.WriteLine(
//                db.Entry(movie1).State
//            );

//            //-------------------------------------------
//            // 4. Modified State
//            //-------------------------------------------

//            movie1.Title = "Updated Demo Movie";

//            Console.WriteLine("\nModified State");
//            Console.WriteLine(
//                db.Entry(movie1).State
//            );

//            //-------------------------------------------
//            // 5. Save Updated Data
//            //-------------------------------------------

//            db.SaveChanges();

//            Console.WriteLine("\nAfter Update SaveChanges()");
//            Console.WriteLine(
//                db.Entry(movie1).State
//            );

//            //-------------------------------------------
//            // 6. Deleted State
//            //-------------------------------------------

//            db.Movies.Remove(movie1);

//            Console.WriteLine("\nDeleted State");
//            Console.WriteLine(
//                db.Entry(movie1).State
//            );

//            //-------------------------------------------
//            // 7. Delete From Database
//            //-------------------------------------------

//            db.SaveChanges();

//            Console.WriteLine("\nDeleted Successfully");

//            //-------------------------------------------
//            // 8. Unchanged State Example
//            //-------------------------------------------

//            var movie2 = db.Movies.FirstOrDefault();

//            if (movie2 != null)
//            {
//                Console.WriteLine("\nUnchanged State");

//                Console.WriteLine(
//                    db.Entry(movie2).State
//                );
//            }

//            //-------------------------------------------
//            // 9. Detached State Manually
//            //-------------------------------------------

//            var movie3 = db.Movies.FirstOrDefault();

//            if (movie3 != null)
//            {
//                db.Entry(movie3).State =
//                    EntityState.Detached;

//                Console.WriteLine("\nDetached Manually");

//                Console.WriteLine(
//                    db.Entry(movie3).State
//                );
//            }

//            //-------------------------------------------
//            // 10. All Entity States
//            //-------------------------------------------

//            Console.WriteLine("\nEntity States");

//            Console.WriteLine(EntityState.Added);

//            Console.WriteLine(EntityState.Modified);

//            Console.WriteLine(EntityState.Deleted);

//            Console.WriteLine(EntityState.Unchanged);

//            Console.WriteLine(EntityState.Detached);
//        }
//    }
//}
















