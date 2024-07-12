let currentFilters = {};

function search() {
    filter();
}

function filter() {
    var searchTerm = document.getElementById('searchTerm').value.toLowerCase();
    var cards = document.querySelectorAll('.list-card');
    var rows = document.querySelectorAll('.table-row');

    // Update currentFilters based on filter inputs
    updateCurrentFilters();

    console.log(currentFilters);
    function checkElement(element) {
        console.log(element);
        // Check search term
        var matchesSearch = searchableFieldNames.some(field =>
            element.dataset[field].toLowerCase().includes(searchTerm)
        );

        // Check filters
        var matchesFilters = Object.entries(currentFilters).every(([filterName, filterValue]) => {
            var formattedFilterName = removeWhiteSpaces(filterName).toLowerCase();
            console.log(formattedFilterName);
            console.log(filterValue)

            if (typeof filterValue === 'boolean') {
                console.log(`filterValue - ${filterValue}`)
                console.log(`element.dataset[formattedFilterName] - ${element.dataset[formattedFilterName]}`)
                return !filterValue || element.dataset[formattedFilterName] === 'true';
            } else if (typeof filterValue === 'object' && 'start' in filterValue && 'end' in filterValue) {
                let value = element.dataset[formattedFilterName];
                let start = filterValue.start ? filterValue.start : -Infinity;
                let end = filterValue.end ? filterValue.end : Infinity;


                // Convert value to appropriate type based on range type
                let rangeType = element.dataset[`${formattedFilterName}_rangetype`];

                console.log(rangeType);

                switch (rangeType) {
                    case 'datetime-local':
                    case 'date':
                        value = new Date(value).getTime();
                        start = new Date(start).getTime();
                        end = new Date(end).getTime();
                        break;
                    case 'number':
                        value = parseFloat(value);
                        start = parseFloat(start);
                        end = parseFloat(end);
                        break;
                }

                
                console.log(value);
                console.log(start);
                console.log(end);
                console.log(isNaN(start) && isNaN(end));
                console.log(isNaN(start));
                console.log(isNaN(end));


                if (isNaN(start) && isNaN(end)) return true;
                else if (isNaN(start)) return value <= end;
                else if (isNaN(end)) return value >= start;
                else return value >= start && value <= end;

            } else if (Array.isArray(filterValue)) {
                return filterValue.includes(element.dataset[formattedFilterName]);
            }
            return true;
        });

        return matchesSearch && matchesFilters;
    }

    cards.forEach(function (card) {
        card.style.display = checkElement(card) ? '' : 'none';
    });

    rows.forEach(function (row) {
        row.style.display = checkElement(row) ? '' : 'none';
    });
}

function updateCurrentFilters() {
    currentFilters = {};

    document.querySelectorAll('.filter-input').forEach(input => {
        const filterName = input.dataset.filter;
        const filterType = input.dataset.filterType;

        console.log(`input - ${input.innerHTML}`);
        console.log(`filterName - ${filterName}`);
        console.log(`filterType - ${filterType}`);

        switch (filterType) {
            case 'checkbox':
                currentFilters[filterName] = input.checked;
                break;
            case 'range':
                if (!currentFilters[filterName]) {
                    currentFilters[filterName] = {};
                }
                if (input.id.endsWith('_start')) {
                    currentFilters[filterName].start = input.value;
                } else if (input.id.endsWith('_end')) {
                    currentFilters[filterName].end = input.value;
                }
                break;
            case 'list':
                if (!currentFilters[filterName]) {
                    currentFilters[filterName] = [];
                }
                if (input.checked) {
                    currentFilters[filterName].push(input.value);
                }
                break;
        }
    });
}

function sort(element) {
    var sortType = element.getAttribute('data-sort');
    var sortLabel = document.getElementById('sortLabel');
    sortLabel.innerText = element.innerText;
    var cards = Array.from(document.querySelectorAll('.list-card'));
    var rows = Array.from(document.querySelectorAll('.table-row'));
    var sortFunction = getSortFunction(sortType);
    cards.sort(sortFunction);
    rows.sort(sortFunction);
    updateView('#cardView', cards);
    updateView('#table tbody', rows);
}

function getSortFunction(sortType) {
    return function (a, b) {
        var aData, bData;
        switch (sortType) {
            case 'dateOfBirth':
                return compareDates(a.dataset.dateofbirth, b.dataset.dateofbirth);
            case 'dateOfBirthDesc':
                return compareDates(b.dataset.dateofbirth, a.dataset.dateofbirth);
            case 'username':
                return compareStrings(a.dataset.username, b.dataset.username);
            case 'usernameDesc':
                return compareStrings(b.dataset.username, a.dataset.username);
            case 'firstName':
                return compareStrings(a.dataset.firstname, b.dataset.firstname);
            case 'firstNameDesc':
                return compareStrings(b.dataset.firstname, a.dataset.firstname);
            case 'lastName':
                return compareStrings(a.dataset.lastname, b.dataset.lastname);
            case 'lastNameDesc':
                return compareStrings(b.dataset.lastname, a.dataset.lastname);
            case 'startDate':
                return compareDates(a.dataset.startdate, b.dataset.startdate);
            case 'startDateDesc':
                return compareDates(b.dataset.startdate, a.dataset.startdate);
            default:
                return 0;
        }
    };
}

function compareStrings(a, b) {
    return a.toLowerCase().localeCompare(b.toLowerCase());
}

function compareDates(a, b) {
    return new Date(a) - new Date(b);
}

function updateView(containerSelector, elements) {
    var container = document.querySelector(containerSelector);
    container.innerHTML = '';
    elements.forEach(function (element) {
        container.appendChild(element);
    });
}



function initializeCurrentValues() {
    // Empty on purpose, nothing to initialize
}