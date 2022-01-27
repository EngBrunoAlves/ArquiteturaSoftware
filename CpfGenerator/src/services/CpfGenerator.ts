export class CpfGenerator {
	public run(): string {
		let n: number = 9;
		let n1: number = this.randomNumber(n);
		let n2: number = this.randomNumber(n);
		let n3: number = this.randomNumber(n);
		let n4: number = this.randomNumber(n);
		let n5: number = this.randomNumber(n);
		let n6: number = this.randomNumber(n);
		let n7: number = this.randomNumber(n);
		let n8: number = this.randomNumber(n);
		let n9: number = this.randomNumber(n);
		let d1: number = n9 * 2 + n8 * 3 + n7 * 4 + n6 * 5 + n5 * 6 + n4 * 7 + n3 * 8 + n2 * 9 + n1 * 10;
		d1 = 11 - (this.mod(d1, 11));
		if (d1 >= 10) d1 = 0;
		let d2: number = d1 * 2 + n9 * 3 + n8 * 4 + n7 * 5 + n6 * 6 + n5 * 7 + n4 * 8 + n3 * 9 + n2 * 10 + n1 * 11;
		d2 = 11 - (this.mod(d2, 11));
		if (d2 >= 10) d2 = 0;

		return '' + n1 + n2 + n3 + '.' + n4 + n5 + n6 + '.' + n7 + n8 + n9 + '-' + d1 + d2;
	}

	private randomNumber(n: number): number {
		let number = Math.round(Math.random() * n);
		return number;
	}

	private mod(dividend: number, divider: number): number {
		return Math.round(dividend - (Math.floor(dividend / divider) * divider));
	}
}