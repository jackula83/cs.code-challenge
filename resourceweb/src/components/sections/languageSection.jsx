import React from 'react';
import Form from '../common/form';
import http from '../../services/httpService';
import { Container } from 'reactstrap';
import config from '../../config.json';

class LanguageSection extends Form {
  localiseLanguage = (languageName) => {
    if (languageName === 'Greek') return 'Ελληνικά';

    return languageName;
  };

  async componentDidMount() {
    const { onSelected } = this.props;
    const { url, language: path } = config.apiEndpoints;
    const { data: languageResponse } = await http.get(`${url}/${path}`);
    const { Result: result } = languageResponse;

    const items = [];

    for (let i = 0; i < result.length; ++i) {
      items[i] = {
        id: result[i].Name,
        filename: result[i].FileName,
        label: this.localiseLanguage(result[i].Name),
        handleOptionSelected: onSelected,
      };
    }

    const data = { ...this.state.data };
    data[LanguageSection.name] = items;

    this.setState({ data });
  }

  render() {
    return (
      <React.Fragment>
        <Container className="pt-5">
          <div className="text-center">
            <h3 className="display-8">Please select a language</h3>
            <div className="d-flex flex-column justify-content-center mb-5">
              {this.renderOptionsFlex(LanguageSection.name, {})}
            </div>
          </div>
        </Container>
      </React.Fragment>
    );
  }
}

export default LanguageSection;
