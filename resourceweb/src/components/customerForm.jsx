import React, { Fragment } from 'react';
import Form from './common/form';
import LanguageSection from './sections/languageSection';
import SpecialtySection from './sections/specialtySection';
import ResourceSection from './sections/resourceSection';

class CustomerForm extends Form {
  state = {
    sections: [],
    currentSection: 0,
    language: '',
    specialty: '',
  };

  handleLanguageSelected = (language) => {
    //console.log(language);
    this.setState({ language, currentSection: this.state.currentSection + 1 });
  };

  handleSpecialtySelected = (specialty) => {
    //console.log(specialty);
    this.setState({ specialty, currentSection: this.state.currentSection + 1 });
  };

  componentDidMount() {
    //console.log('cdm', this.state);

    this.setState({
      sections: [
        <LanguageSection onSelected={this.handleLanguageSelected} />,
        <SpecialtySection onSelected={this.handleSpecialtySelected} />,
      ],
    });
  }

  render() {
    const { currentSection, sections, language, specialty } = this.state;

    //console.log('customerForm.render', currentSection);

    return (
      <Fragment>
        {currentSection < sections.length ? (
          sections[currentSection]
        ) : (
          <ResourceSection language={language} specialty={specialty} />
        )}
      </Fragment>
    );
  }
}

export default CustomerForm;
