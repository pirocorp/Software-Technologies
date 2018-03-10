function solve (args) {
    let nums = args[0].split(' ').map(Number);
    console.log(
        checkSum(nums[0], nums[1], nums[2]) ||
        checkSum(nums[0], nums[2], nums[1]) ||
        checkSum(nums[1], nums[2], nums[0]) || 'No');
    function checkSum(num1, num2, sum) {
        if(num1 + num2 != sum){
            return false;
        }
        if(num1 > num2){
            [num1, num2] = [num2, num1];
        }
        return `${num1} + ${num2} = ${sum}`;
    }
}
solve(['3 8 11']);