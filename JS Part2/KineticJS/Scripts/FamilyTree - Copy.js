(function() {
    'use strict';
    window.onload = function() {

        var familyTree3 = [{
            mother: 'Maria Petrova',
            father: 'Georgi Petrov',
            children: ['Teodora Petrova', 'Peter Petrov']
        }, {
            mother: 'Petra Stamatova',
            father: 'Todor Stamatov',
            children: ['Teodor Stamatov', 'Boris Opanov', 'Maria Petrova']
        }, {
            mother: 'Boriana Stamatova',
            father: 'Teodor Stamatov',
            children: ['Martin Stamatov', 'Albena Dimitrova']
        }, {
            mother: 'Albena Dimitrova',
            father: 'Ivan Dimitrov',
            children: ['Doncho Dimitrov', 'Ivaylo Dimitrov']
        }, {
            mother: 'Donika Dimitrova',
            father: 'Doncho Dimitrov',
            children: ['Vladimir Dimitrov', 'Iliana Dobreva']
        }, {
            mother: 'Juliana Petrova',
            father: 'Peter Petrov',
            children: ['Dimitar Petrov', 'Galina Opanova']
        }, {
            mother: 'Iliana Dobreva',
            father: 'Delian Dobrev',
            children: ['Dimitar Dobrev', 'Galina Pundiova']
        }, {
            mother: 'Galina Pundiova',
            father: 'Martin Pundiov',
            children: ['Dimitar Pundiov', 'Todor Pundiov']
        }, {
            mother: 'Maria Pundiova',
            father: 'Dimitar Pundiov',
            children: ['Georgi Pundiov', 'Stoian Pundiov']
        }, {
            mother: 'Dobrinka Pundiova',
            father: 'Georgi Pundiov',
            children: ['Pavel Pundiov', 'Marian Pundiov']
        }, {
            mother: 'Elena Pundiova',
            father: 'Marian Pundiov',
            children: ['Kamen Pundiov', 'Hristina Ivancheva']
        }, {
            mother: 'Hristina Ivancheva',
            father: 'Martin Ivanchev',
            children: ['Kamen Ivanchev', 'Evgeny Ivanchev']
        }, {
            mother: 'Maria Ivancheva',
            father: 'Kamen Ivanchev',
            children: ['Ivo Ivanchev', 'Delian Ivanchev']
        }, {
            mother: 'Nadejda Ivancheva',
            father: 'Ivo Ivanchev',
            children: ['Petio Ivanchev', 'Marin Ivanchev']
        }, {
            mother: 'Natalia Ivancheva',
            father: 'Delian Ivanchev',
            children: ['Galina Hristova']
        }, {
            mother: 'Galina Opanova',
            father: 'Boian Opanov',
            children: ['Maria Opanova', 'Patar Opanov']
        }, {
            mother: 'Galina Hristova',
            father: 'Marin Hristov',
            children: ['Petar Hristov', 'Kamen Hristov', 'Ivan Hristov']
        }, {
            mother: 'Simona Hristova',
            father: 'Kamen Hristov',
            children: ['Elena Hristova', 'Valeria Hristova']
        }];


        var familyTree3 = [{
            mother: 'Maria Maria',
            father: 'Gosho Goshov',
            children: ['Little Peshko']
        }, {
            mother: 'Goshos Grandma1',
            father: 'Goshos Grandpa1',
            children: ['Goshos Father']
        }, {
            mother: 'Goshos Mother',
            father: 'Goshos Father',
            children: ['Gosho Goshov', 'Goshos Brother']
        }, {
            mother: 'Marias Mother',
            father: 'Marias Father',
            children: ['Maria Maria', 'Marias Brother']
        }, {
            mother: 'Goshos Grandma2',
            father: 'Goshos Grandpa2',
            children: ['Goshos Mother', 'Goshos Aunt']
        }];

        var familyTree = [{
            mother: 'Ganka',
            father: 'Petur',
            children: ['Stefan', 'Rumqna']
        }, {
            mother: 'Stanka',
            father: 'Rumen',
            children: ['Stamen', 'Petq', 'Stoqn']
        }, {
            mother: 'Mariq',
            father: 'Ico',
            children: ['Ivo']
        }, {
            mother: 'Pavlina',
            father: 'Genadi',
            children: ['Jivka']
        }, {
            mother: 'Diana',
            father: 'Pesho',
            children: ['Iva']
        }, {
            mother: 'Iva',
            father: 'Stefan',
            children: ['Joro']
        }, {
            mother: 'Jivka',
            father: 'Joro',
            children: ['Stefani', 'Daniela']
        }, {
            mother: 'Petq',
            father: 'Ivo',
            children: ['Doncho', 'Monika']
        }, {
            mother: 'Rumqna',
            father: 'Stamen',
            children: ['Gancho', 'Mihaela']
        }];

        var familyMembers = [];

        for (var i = 0; i < familyTree.length; i++) {
            resolveRelationships(familyTree[i], 'mother', 'father');
            resolveRelationships(familyTree[i], 'father', 'mother');
        }

        var currentGroup = 100;
        var minLevel = 100;
        var maxLevel = 100;
        determineLevels();

        for (var person in familyMembers) {
            console.log(person + '-' + familyMembers[person].group + ':');
            console.log(familyMembers[person]);
        }
        console.log(minLevel + " " + maxLevel);

        var stageWidth = 1000;
        var stageHeigth = 600;
        var squareWidth = 80;
        var squareHeight = 20;
        var xSpace = 20;
        var ySpace = 50;

        var stage = new Kinetic.Stage({
            container: 'container',
            width: stageWidth,
            height: stageHeigth
        });

        var layer = new Kinetic.Layer();
        var levelCounters = [];
        for (var i = minLevel; i <= maxLevel; i++) {
            levelCounters[i] = 0;
        }

        for (var name in familyMembers) {
            person = familyMembers[name];
            var personLevel = person.level - minLevel;
            var rect = new Kinetic.Rect({
                x: levelCounters[person.level] * (squareWidth + xSpace),
                y: (person.level - minLevel) * (squareHeight + ySpace),
                width: squareWidth,
                height: squareHeight,
                fill: 'white',
                stroke: 'black',
                strokeWidth: 2,
                cornerRadius: 5
            });
            var simpleText = new Kinetic.Text({
                x: levelCounters[person.level] * (squareWidth + xSpace) + 5,
                y: (person.level - minLevel) * (squareHeight + ySpace),
                text: name,
                fontSize: 16,
                fontFamily: 'Calibri',
                fill: 'green'
            });
            layer.add(rect);
            layer.add(simpleText);
            person.x = levelCounters[person.level];
            levelCounters[person.level]++;
        }

        for (var name in familyMembers) {
            person = familyMembers[name];
            if (!person.children) {
                continue;
            }
            var personLevel = (person.level - minLevel) * (squareHeight + ySpace) + squareHeight;
            for (var i = 0; i < person.children.length; i++) {
                var childX = familyMembers[person.children[i]].x * (squareWidth + xSpace) + 25;
                var childLevel = (familyMembers[person.children[i]].level - minLevel) * (squareHeight + ySpace);
                var curvedLine = new Kinetic.Line({
                    points: [person.x * (squareWidth + xSpace) + 25, personLevel, childX, childLevel],
                    stroke: 'red',
                    strokeWidth: 2,
                    lineJoin: 'round',
                    //                    tension: 1
                });
                layer.add(curvedLine);
            };
        }


        stage.add(layer);




        function determineLevels() {
            var person;
            for (var name in familyMembers) {
                person = familyMembers[name];
                if (!person.group) {
                    person.level = 100;
                    currentGroup++;
                    person.group = currentGroup;
                }
                enumeratePeople(person);
            }
        }

        function enumeratePeople(person) {
            minLevel = Math.min(minLevel, person.level);
            maxLevel = Math.max(maxLevel, person.level);
            if (person.couple && !familyMembers[person.couple].level) {
                familyMembers[person.couple].level = person.level;
                familyMembers[person.couple].group = currentGroup;
                enumeratePeople(familyMembers[person.couple]);
            }
            if (person.mother && !familyMembers[person.mother].level) {
                familyMembers[person.mother].level = person.level - 1;
                familyMembers[person.mother].group = currentGroup;
                enumeratePeople(familyMembers[person.mother]);
            }
            if (person.father && !familyMembers[person.father].level) {
                familyMembers[person.father].level = person.level - 1;
                familyMembers[person.father].group = currentGroup;
                enumeratePeople(familyMembers[person.father]);
            }
            if (person.children) {
                var child;
                for (var i = 0; i < person.children.length; i++) {
                    child = familyMembers[person.children[i]];
                    if (!child.level) {
                        child.level = person.level + 1;
                        child.group = currentGroup;
                        enumeratePeople(child);
                    }
                }
            }
        }

        function resolveRelationships(node, person, couple) {
            var personName = node[person];

            if (!familyMembers[personName]) {
                familyMembers[personName] = {};
            }
            var currentPerson = familyMembers[personName];
            currentPerson.couple = node[couple];
            currentPerson.type = person;
            currentPerson.children = [];
            for (var j = 0; j < node.children.length; j++) {
                currentPerson.children[j] = node.children[j];
                if (!familyMembers[node.children[j]]) {
                    familyMembers[node.children[j]] = {};
                }
                familyMembers[node.children[j]][person] = node[person];
            }
        }

    }

})();

/*

    curvedLine = new Kinetic.Line({
      points: [250, 50, 400, 50, 400, 200, 250, 200, 250, 100, 350, 100, 350, 150, 300, 150],
      stroke: 'green',
      strokeWidth: 2,
      lineJoin: 'round',
      tension: 1
    });

        function createChain() {
            var person;
            var child;
            var startOfChain = '';
            for (var name in familyMembers) {
                person = familyMembers[name];
                if (person.type && person.type === 'father') {
                    if (!person.mother && person.children && person.children.length === 1) {
                        child = familyMembers[person.children[0]];
                        startOfChain = person;
                        for (var i = 0; i < child.children.length; i++) {
                            if (familyMembers[child.children[i]].children) {
                                startOfChain = '';
                                break;
                            }
                        }
                        console.log(person);
                    }
                }
                //                if (startOfChain) {
                //                    break;
                //}
            }
            //            console.log(person);
        }



          if(familyMembers.indexOf(familyTree[i].father) === -1) {
            familyMembers.push(familyTree[i].father);
          }


        for (var tree in familyTree[i]) {
          if (familyTree[i][tree] instanceof Array) {
            for (var j = familyTree[i][tree].length - 1; j >= 0; j--) {
              console.log(tree + ' ' + familyTree[i][tree][j] + ' ' + typeof familyTree[i][tree][j]);
            }
          } else {
            console.log(tree + ' ' + familyTree[i][tree] + ' ' + typeof familyTree[i][tree]);
          }
        }
//        familyTree[i]
      }




      var stage = new Kinetic.Stage({
          container: 'container',
          width: 800,
          height: 600
      });

      var layer = new Kinetic.Layer();







/*    var blob, circle, curvedLine, layer, polygon, rect, stage, straightLine;
    stage = new Kinetic.Stage({
      container: 'container',
      width: 700,
      height: 550
    });
    layer = new Kinetic.Layer();
    rect = new Kinetic.Rect({
      x: 50,
      y: 350,
      width: 57,
      height: 93,
      fill: 'yellowgreen',
      stroke: '#CCCCCC'
    });
    circle = new Kinetic.Circle({
      x: 200,
      y: 350,
      radius: 45,
      fill: 'purple',
      stroke: 'blue',
      strokeWidth: 3
    });

    var simpleText = new Kinetic.Text({
        x: stage.width() / 2,
        y: 15,
        text: 'Simple Text',
        fontSize: 30,
        fontFamily: 'Calibri',
        fill: 'green'
      });
    
    straightLine = new Kinetic.Line({
      points: [50, 50, 200, 50, 200, 200, 50, 200, 50, 100, 150, 100, 150, 150, 100, 150],
      stroke: 'green',
      strokeWidth: 2,
      lineJoin: 'round'
    });
    curvedLine = new Kinetic.Line({
      points: [250, 50, 400, 50, 400, 200, 250, 200, 250, 100, 350, 100, 350, 150, 300, 150],
      stroke: 'green',
      strokeWidth: 2,
      lineJoin: 'round',
      tension: 1
    });
    polygon = new Kinetic.Line({
      points: [300, 300, 450, 300, 450, 350, 400, 350, 400, 500, 350, 500, 350, 350, 300, 350],
      stroke: 'green',
      fill: 'yellowgreen',
      strokeWidth: 2,
      lineJoin: 'round',
      closed: true
    });
    blob = new Kinetic.Line({
      points: [500, 300, 650, 300, 650, 350, 600, 350, 600, 500, 550, 500, 550, 350, 500, 350],
      stroke: 'blue',
      fill: 'purple',
      strokeWidth: 2,
      lineJoin: 'round',
      closed: true,
      tension: 0.5
    });
    layer.add(rect);
    layer.add(circle);
    layer.add(straightLine);
    layer.add(curvedLine);
    layer.add(polygon);
    layer.add(blob);
    return stage.add(layer);
  }; */