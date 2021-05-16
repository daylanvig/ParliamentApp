import MathUtils from '../MathUtils'; // SUT

describe('calculatePercentageDifference', () => {
  test('should return difference is 0', () => {
    expect(MathUtils.calculatePercentageDifference(100, 100)).toBe(0);
  });

  test('should return difference is 100', () => {
    expect(MathUtils.calculatePercentageDifference(0, 100)).toBe(100);
  });

  test('should throw when trying to divide by 0', () => {
    expect(() => MathUtils.calculatePercentageDifference(100, 0)).toThrow();
  });
});