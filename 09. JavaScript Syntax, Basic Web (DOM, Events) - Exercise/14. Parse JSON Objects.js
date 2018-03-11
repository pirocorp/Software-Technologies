function solve(inputLines) {
    let objects = [];

    for (let i = 0; i < inputLines.length; i++){
        let currentLine = inputLines[i];
        let currentObject = JSON.parse(currentLine);
        objects.push(currentObject);
    }

    for (let object of objects){
        console.log(`Name: ${object.name}`);
        console.log(`Age: ${object.age}`);
        console.log(`Date: ${object.date}`);
    }
}

solve(['{"name":"Gosho","age":10,"date":"19/06/2005"}', '{"name":"Tosho","age":11,"date":"04/04/2005"}']);