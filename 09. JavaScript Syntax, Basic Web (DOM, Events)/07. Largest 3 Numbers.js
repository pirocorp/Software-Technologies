function largestThreeNums(args) {
    let count = Math.min(3, args.length);
    let nums = args
        .map(Number)
        .sort((a, b) => b - a)
        .splice(0,count);
    console.log(nums.join("\n"));
}

largestThreeNums(['15', '20']);