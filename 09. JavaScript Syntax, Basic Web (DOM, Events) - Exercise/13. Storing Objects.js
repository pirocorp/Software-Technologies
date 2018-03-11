function solve(inputLines) {
    let students = [];

    for(let i = 0; i < inputLines.length; i++){
        let tokens = inputLines[i].split('->').map(x => x.trim());
        let name = tokens[0];
        let age = Number(tokens[1]);
        let grade = Number(tokens[2]);
        let currentStudent = {name:name, age:age, grade:grade};
        students.push(currentStudent);
    }

    for(let student of students){
        console.log(`Name: ${student.name}`);
        console.log(`Age: ${student.age}`);
        console.log(`Grade: ${student.grade.toFixed(2)}`);
    }
}

solve(['Pesho -> 13 -> 6.00', 'Ivan -> 12 -> 5.57', 'Toni -> 13 -> 4.90']);