/// <reference path="class.js" />
/// <reference path="underscore-min.js" />
(function() {

    //Task 1: Write a method that from a given array of students finds all students whose
    //first name is before its last name alphabetically. Print the students in descending order by
    //full name. Use Underscore.js

    function Student(fname, lname, age, marks) {
        this.fname = fname;
        this.lname = lname;
        this.age = age;
        this.marks = marks;
    }

    Student.prototype.getFullName = function() {
        return this.fname + ' ' + this.lname;
    }

    Student.prototype.getAverageMark = function() {
        var averageMark = 0;
        _.each(this.marks, function(mark) {
            averageMark += mark;
        });
        return (averageMark / this.marks.length).toFixed(2);
    }

    var students = [
        new Student("Ivan", "Petrov", 15, [5, 3, 4, 1]),
        new Student("Nikolay", "Stoyanov", 18, [3, 5, 5, 6]),
        new Student("Kiril", "Iliev", 25, [4, 6, 2, 3]),
        new Student("Stamat", "Mentata", 23, [4, 2, 2, 3]),
        new Student("Ivan", "Nikolov", 20, [6, 5, 6, 5]),
        new Student("Asan", "Mechkoboreca", 17, [2, 5, 6, 5])
    ];

    console.info('Initial students array:')
    _.each(students, function(student) {
        console.log(' - ' + student.getFullName() + '. Age: ' + student.age + '. marks: ' + student.marks);
    });

    var sortedStudents = _.chain(students)
        .filter(function(student) {
            return student.fname < student.lname;
        })
        .sortBy(function(student) {
            return student.getFullName()
        })
        .value().reverse();

    console.warn('Task 1: Filter and sort students');
    console.info('Task 1 result:');
    _.each(sortedStudents, function(item) {
        console.log(' - ' + item.getFullName());
    });


    // Task 2: Write function that finds the first name and last name of all students 
    // with age between 18 and 24. Use Underscore.js

    console.warn('Task 2: Students with age between 18 and 24');
    console.info('Task 2 result:');
    var studentsbetween18And24 = _.chain(students)
        .filter(function(student) {
            return student.age >= 18 && student.age <= 24;
        })
        .each(function(student) {
            console.log(' - ' + student.getFullName() + '. Age: ' + student.age);
        });


    //Task 3: Write a function that by a given array of students finds the student with highest marks
    console.warn('Task 3: Students with best and worst average score');
    console.info('Task 3 result:');

    var studentsSortByAverageMakrs = _.sortBy(students, function(student) {
        return student.getAverageMark();
    });

    console.log('Student with best score: ' + _.last(studentsSortByAverageMakrs).getFullName() +
        ' - average score: ' + _.last(studentsSortByAverageMakrs).getAverageMark());
    console.log('Student with worst score: ' + _.first(studentsSortByAverageMakrs).getFullName() +
        ' - average score: ' + _.first(studentsSortByAverageMakrs).getAverageMark());



    function Animal(name, species, numLegs) {
        this.name = name;
        this.species = species;
        this.numLegs = numLegs;
    }

    var animals = [
        new Animal("Dog", "mammal", 4),
        new Animal("Centipede George", "insect", 100),
        new Animal("Centipede WW2 survivor", "insect", 78),
        new Animal("Human", "mammal", 2),
        new Animal("Dolphin", "mammal", 0),
        new Animal("Birdie", "bird", 2),
        new Animal("Prairie dog", "mammal", 4),
        new Animal("Angry Bird", "bird", 0),
        new Animal("Butterfly", "insect", 6),
        new Animal("Teenage Mutant Ninja Bird", "bird", 4)
    ];

    Animal.prototype.toString = function() {
        return this.name + '. Species: ' + this.species + ', number of legs: ' + this.numLegs;
    }

    // Task 4: Write a function that by a given array of animals, groups them 
    // by species and sorts them by number of legs
    console.warn('Task 4: Group and sort animals');
    console.info('Task 4 result:');

    _.chain(animals)
        .sortBy('numLegs')
        .groupBy('species')
        .each(function(animalGroup) {
            console.log('Species: ' + animalGroup[0].species);
            _.each(animalGroup, function(animal) {
                console.log(' - ' + animal.toString());
            })
        });

    // Task 5: By a given array of animals, find the total number of legs
    console.warn('Task 5: Count numer of legs of all animals');
    console.info('Task 5 result:');

    console.log('Total numer of legs: ' +
        _.chain(animals)
        .pluck('numLegs')
        .reduce(function(memo, num) {
            return memo + num;
        }, 0)
        .value()
    );

    function Book(name, genre, author) {
        this.name = name;
        this.genre = genre;
        this.author = author;
    }

    var books = [];

    books.push(new Book("The Godfather", "Criminal", "Mario Puzo"));
    books.push(new Book("Lord Of The Rings", "Fantasy", "J. R. R. Tolkien"));
    books.push(new Book("Unfinished Tales and The History of Middle-earth", "Fantasy", "J. R. R. Tolkien"));
    books.push(new Book("Hobbit", "Fantasy", "J. R. R. Tolkien"));
    books.push(new Book("The Last Don", "Criminal", "Mario Puzo"));
    books.push(new Book("All Quiet on the Western Front", "Novel", "Erich Maria Remarque"));

    // Task 6: By a given collection of books, find the most popular author 
    // (the author with the highest number of books)
    console.warn('Task 6: Find most popular author');
    console.info('Task 6 result:');
    console.log('Most popular autohr is ' +
        _.chain(books)
        .countBy('author')
        .pairs()
        .sortBy('1')
        .last()
        .value()[0]
    );

    // Task 7: By an array of people find the most common first and last name. Use underscore.
    console.warn('Task 7: Find most popular first name');
    console.info('Task 7 result:');
    console.dir('Most popular student name is ' +
        _.chain(students)
        .countBy('fname')
        .pairs()
        .sortBy('1')
        .last()
        .value()[0]
    );


}());