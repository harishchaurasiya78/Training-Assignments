// __tests__/api.test.js
const request = require("supertest");
const app = require("../server");

describe("API Tests", () => {
  it("should return API is running", async () => {
    const res = await request(app).get("/");
    expect(res.text).toBe("API is running...");
  });
});
