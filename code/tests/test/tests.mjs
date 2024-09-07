// Step 1: Import necessary modules dynamically


import { use, expect }   from 'chai';
import chaiHttp from 'chai-http';
const chai = use(chaiHttp);

const request = chai.request.execute;


const baseUrl = "http://localhost:5100";

// Step 2: Describe the test suite
describe('Health', function() {
  it('should return status 200 and expected response', function(done) {

    request(baseUrl)
      .get('/health')
      .end(function(err, res) {
        expect(res).to.have.status(200);
        expect(res.text).to.equal ("Healthy");
        // Add more assertions based on the expected response structure
       // expect(res.body).to.have.property('status', 'ok');
     done();
      });
  });
});