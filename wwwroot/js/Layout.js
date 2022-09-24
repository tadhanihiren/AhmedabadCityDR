document.addEventListener("DOMContentLoaded", () => {
    /* for nasted dropdown*/
    {
        let dropdowns = document.querySelectorAll('.layout-dropdown-toggle')
        dropdowns.forEach((dd) => {
            dd.addEventListener('click', function (e) {
                //console.log('Click');
                var el = this.nextElementSibling
                el.style.display = el.style.display === 'block' ? 'none' : 'block'
            })
        })
    }

    /* Future Date Disable In for all date by class name = '.date-today'*/
    {
        var todayDate = new Date();
        // getMonth() returns the month (from 0 to 11) of a date.
        // Note: 0 = January, 1 = February etc.
        var month = todayDate.getMonth() + 1;
        var year = todayDate.getUTCFullYear();
        var date = todayDate.getDate();
        if (month < 10) {
            month = "0" + month //'0' + 4 = 04
        }
        if (date < 10) {
            date = "0" + date;
        }
        var maxDate = year + "-" + month + "-" + date;

        // Get a NodeList of all .demo elements
        const demoClasses = document.querySelectorAll('.date-today');

        // Change the attribute of multiple elements with a loop
        demoClasses.forEach(element => {
            element.setAttribute("max", maxDate);
            element.setAttribute("value", maxDate);
        });
    }
});