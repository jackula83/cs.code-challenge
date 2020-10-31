import React, { Component } from 'react';
import Form from './common/form';
import http from '../services/httpService';
import config from '../config.json';

class RosterForm extends Form {
  async componentDidMount() {
    // TODO axios post: /url/roster
    const { url, roster: path } = config.apiEndpoints;
    await http.post(`${url}/${path}`);

    // go back to default page
    this.handleRedirect('/');
  }

  render() {
    return <h3 className="display-4">Resetting Roster...</h3>;
  }
}

export default RosterForm;
