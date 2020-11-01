import React from 'react';
import Form from '../common/form';
import http from '../../services/httpService';
import { Container } from 'reactstrap';
import config from '../../config.json';

class SpecialtySection extends Form {
  static otherOption = 'Other';

  async componentDidMount() {
    const { onSelected } = this.props;
    const { url, specialty: path } = config.apiEndpoints;
    const { data: specialtyResponse } = await http.get(`${url}/${path}`);
    const { Result: result } = specialtyResponse;

    const items = [];

    for (let i = 0; i < result.length; ++i) {
      items[i] = {
        id: result[i].SpecialtyCriteria,
        filename: result[i].FileName,
        label: result[i].SpecialtyCriteria,
        handleOptionSelected: onSelected,
      };
    }

    // add the none option
    items[items.length] = {
      id: SpecialtySection.otherOption,
      filename: 'nonevehicle.png',
      label: SpecialtySection.otherOption,
      handleOptionSelected: onSelected,
    };

    const data = { ...this.state.data };
    data[SpecialtySection.name] = items;

    this.setState({ data });
  }

  render() {
    return (
      <React.Fragment>
        <Container className="pt-5">
          <div className="text-center">
            <h3 className="display-8">What are you looking for?</h3>
            <div className="d-flex flex-wrap justify-content-center mb-5">
              {this.renderOptionsFlex(SpecialtySection.name, {})}
            </div>
          </div>
        </Container>
      </React.Fragment>
    );
  }
}

export default SpecialtySection;
