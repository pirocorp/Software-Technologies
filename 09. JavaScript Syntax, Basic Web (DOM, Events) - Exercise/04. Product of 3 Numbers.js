function solve(nums) {
    nums = nums.map(Number).filter(x => x < 0);
    if(nums.length % 2 === 0){
        return 'Positive';
    } else {
        return 'Negative';
    }
}

console.log(solve(['2', '-3', '-1']));