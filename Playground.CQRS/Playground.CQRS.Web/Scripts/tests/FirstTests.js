/// <reference path="../jasmine.js" />

describe("First feature", function () {
	it("First test", function () {
		var expected = false;
		var actual = true;
		expect(actual).toBe(!expected);
	});

	it("Second test", function () {
		var expected = true;
		var actual = true;
		expect(actual).toBe(expected);
	});
	/*xit will skip the test
	xit("should be skipped!", function () {
		var expected = true;
		var actual = false;
		expect(actual).toBe(expected);
	});*/
});