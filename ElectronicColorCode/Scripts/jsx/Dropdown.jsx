

Dropdown = React.createClass({
    getInitialState: function() {
        return {
            //value: 'select'            
            selectBandAValue:"0",
            selectBandBValue:"0",
            selectBandCValue:"1",
            selectBandDValue:"20"
        };
    },
    handleBandAChange: function(event){
        this.setState({selectBandAValue: event.target.value,
            selectBandAIndex: event.target.index});
    },
    handleBandBChange: function(event){
        this.setState({selectBandBIndex: event.target.index,
            selectBandBValue: event.target.value});
    },
    handleBandCChange: function(event){
        this.setState({selectBandCIndex: event.target.index,
            selectBandCValue: event.target.value});
    },
    handleBandDChange: function(event){
        this.setState({selectBandDIndex: event.target.index,
            selectBandDValue: event.target.value});
    },
    displayValueClick: function () {
        let bandAVal;
        
        $.ajax({
            url: 'OhmValue/GetOhmValue',
            dataType:'json',
            data:{'bandAValue':this.state.selectBandAValue,
                'bandBValue':this.state.selectBandBValue,
                'bandCValue':this.state.selectBandCValue,
                'bandDValue':this.state.selectBandDValue},
            cache: false,
            success: function(data){
                this.setState({finalValue:data});
                console.log(this.state.finalValue);
            }.bind(this),
            error: function(xhr, status, err){
                console.log(err);
            }.bind(this)
        });
    },
    render: function(e){
        
        //this.props.bandA = this.state.selectBandAValue;
        console.log(this.state.selectBandAValue)
        {this.state.selectBandAValue}
        return(
        <div>
    <center>
         <div className="col-md-3 help-block center">
<label className="col-md-11 help-block center">Band A Color</label>
          <select value={this.state.selectBandAValue}
        onChange={this.handleBandAChange}>
        <option value="0">Black</option>
        <option value="1">Brown</option>
        <option value="2">Red</option>
        <option value="3">Orange</option>
        <option value="4">Yellow</option>
        <option value="5">Green</option>
        <option value="6">Blue</option>
        <option value="7">Violet</option>
        <option value="8">Gray</option>
        <option value="9">White</option>
    </select>
    </div>

    <div className="col-md-3 help-block center">
<center><label className="col-md-11 help-block center">Band B Color</label></center>
          <select value={this.state.selectBandBValue}
        onChange={this.handleBandBChange}>
            <option value="0">Black</option>
            <option value="1">Brown</option>
            <option value="2">Red</option>
            <option value="3">Orange</option>
            <option value="4">Yellow</option>
            <option value="5">Green</option>
            <option value="6">Blue</option>
            <option value="7">Violet</option>
            <option value="8">Gray</option>
            <option value="9">White</option>
         </select>
        </div>

        <div className="col-md-3 help-block center">
<label className="col-md-11 help-block center">Band C Color</label>
              <select value={this.state.selectBandCValue}
        onChange={this.handleBandCChange}>
        <option value="1">Black</option>
        <option value="10">Brown</option>
        <option value="100">Red</option>
        <option value="1000">Orange</option>
        <option value="10000">Yellow</option>
        <option value="100000">Green</option>
        <option value="1000000">Blue</option>
        <option value="10000000">Violet</option>
        <option value="100000000">Gray</option>
        <option value="1000000000">White</option>
        <option value="0.001">Pink</option>
        <option value="0.01">Silver</option>
        <option value="0.1">Gold</option>
        </select>
        </div>

        <div className="col-md-3 help-block center">
<label className="col-md-11 help-block center">Band D Color</label>
            <select value={this.state.selectBandDValue}
        onChange={this.handleBandDChange}>
        <option value="20">None</option>
        <option value="10">Silver</option>
        <option value="5">Gold</option>
        <option value="1">Brown</option>
        <option value="2">Red</option>
        <option value="0.5">Green</option>
        <option value="0.25">Blue</option>
        <option value="0.1">Violet</option>
        <option value="0.05">Gray</option>
        </select>
        </div>
    
        <div className="col-md-11 help-block center">
                  <button onClick={this.displayValueClick}>
                   Display Value
                </button>
              </div>
        <div className="col-md-11 help-block center">
            <label className="greenFont">{this.state.finalValue == undefined ?"" : this.state.finalValue.FinalValue + " " + this.state.finalValue.Tolerance}</label>
        </div>
    </center>
        </div>
        );
    }
});

React.render(
<Dropdown />, document.getElementById('ddContainer')
);