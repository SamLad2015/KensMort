import {Candidate} from '../app/shared/candidate';
import {ADD_CANDIDATE, UPDATE_CANDIDATE, DELETE_CANDIDATE, LOAD_CANDIDATES} from './constants';
import * as _ from 'lodash';

export interface IAppState {
  candidates: Candidate[];
}
export const INITIAL_STATE: IAppState = {
  candidates: []
};
export function rootReducer(state = INITIAL_STATE, action) {
  switch (action.type) {
    case LOAD_CANDIDATES:
      return {
        ...state,
        candidates: [...action.payload]
      };
    case ADD_CANDIDATE:
      const newId = _.maxBy(state.candidates, 'id').id + 1;
      action.payload.id = newId;
      return {
        ...state,
        candidates: [...state.candidates, action.payload]
      };
    case UPDATE_CANDIDATE:
      state.candidates = state.candidates.filter(item => item.id !== action.payload.id);
      return {
        ...state,
        candidates: [...state.candidates, action.payload]
      };
    case DELETE_CANDIDATE:
      return {
        ...state,
        candidates: [...state.candidates.filter(item => item.id !== action.payload.id)]
      };
  }
  return state;
}
