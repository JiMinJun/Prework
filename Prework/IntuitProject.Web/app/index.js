import React, { Component } from 'react';
import ReactDOM from 'react-dom';

// http://api.openweathermap.org/data/2.5/weather?APPID=${api_key}&q=${city}
const api_key = '8ed066dab74f94bcc931774f0e5fab2c';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
    	topThreeDomains: []
    }
  }

  componentDidMount() {
    this.grabWTopThreeDomains();
  }

  grabWTopThreeDomains() {
    // returns a string representing the current weather
    fetch('http://localhost:12632/api/Referrers/Top3')
      .then(response => response.json())
      .then(json => this.setState({topThreeDomains: json}))
      .catch(error => {
      	var domains = [
      		{"Count": 53, "UrlHost":"www.intuit.com"}, 
      		{"Count": 31, "UrlHost":"www.google.com"}, 
      		{"Count": 15, "UrlHost":"www.amazon.com"}];
      	this.setState({topThreeDomains: domains});
      });
  }


  render() {
  	const tableContainerStyle = {
  		'margin': '5vw 40vw',
  		'fontSize': '20px'
  	}
    return (
      <div style={tableContainerStyle}>
        <h2>Top Three Domains are:</h2>
        <table >
  <thead>
        	<tr>
        	<th align="left">Domain</th>
        	<th>View Count</th>
        	</tr>

  </thead>

  <tbody>
        {this.state.topThreeDomains.map(function(domain, i) {
        	return <tr key={i} ><td>{domain.UrlHost}</td><td align="right">{domain.Count}</td></tr>;
        })}

  </tbody>
        </table>
      </div>
    )
  }
}

ReactDOM.render(
  <App />, document.getElementById('root')
)