import React from 'react';
import Form from '../common/form';
import http from '../../services/httpService';
import { Container } from 'reactstrap';
import config from '../../config.json';

class ResourceSection extends Form {
  state = {
    name: '',
    title: '',
    language: {},
    specialty: {},
  };

  async componentDidMount() {
    const { language, specialty } = this.props;

    //console.log('ResourceSection.cdm', language, specialty);

    if (language.length === 0 || specialty.length === 0) return;

    this.setState({ language, specialty });

    const { url, resource: path } = config.apiEndpoints;
    const { data: resourceResponse } = await http.get(
      `${url}/${path}/${language}/${specialty}`
    );
    const { Name: name } = resourceResponse;

    this.setState({
      title:
        name == undefined
          ? 'All salespeople are busy. Please wait.'
          : 'You have been assigned:',
    });

    this.setState({ name });
  }

  render() {
    const { name, title } = this.state;

    return (
      <React.Fragment>
        <Container className="pt-5">
          <div className="text-center">
            <h3 className="display-8">{title}</h3>
            <h4 className="lead">{name}</h4>
            <p className="text-muted py-3">
              Enter a New Customer or Reset State to continue.
            </p>
          </div>
        </Container>
      </React.Fragment>
    );
  }
}

export default ResourceSection;
