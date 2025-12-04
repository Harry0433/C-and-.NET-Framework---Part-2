[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")] Insuree insuree)
{
    if (ModelState.IsValid)
    {
        // Start base rate
        decimal quote = 50m;

        // Age calculation
        var today = DateTime.Today;
        int age = today.Year - insuree.DateOfBirth.Year;
        if (insuree.DateOfBirth > today.AddYears(-age)) age--;

        if (age <= 18)
        {
            quote += 100;
        }
        else if (age >= 19 && age <= 25)
        {
            quote += 50;
        }
        else
        {
            quote += 25;
        }

        // Car Year
        if (insuree.CarYear < 2000)
        {
            quote += 25;
        }
        else if (insuree.CarYear > 2015)
        {
            quote += 25;
        }

        // Car Make / Model checks
        if (insuree.CarMake.ToLower() == "porsche")
        {
            quote += 25;
            if (insuree.CarModel.ToLower() == "911 carrera")
            {
                quote += 25;
            }
        }

        // Speeding tickets
        quote += insuree.SpeedingTickets * 10;

        // DUI adds 25%
        if (insuree.DUI)
        {
            quote *= 1.25m;
        }

        // Full coverage adds 50%
        if (insuree.CoverageType)
        {
            quote *= 1.50m;
        }

        insuree.Quote = quote;

        db.Insurees.Add(insuree);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    return View(insuree);
}
