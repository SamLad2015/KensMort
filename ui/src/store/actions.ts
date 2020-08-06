import {ADD_CANDIDATE, DELETE_CANDIDATE, LOAD_CANDIDATES, UPDATE_CANDIDATE} from './constants';

export const LoadCandidates = payload => ({
  type: LOAD_CANDIDATES,
  payload
});

export const AddCandidate = payload => ({
  type: ADD_CANDIDATE,
  payload
});

export const UpdateCandidate = payload => ({
  type: UPDATE_CANDIDATE,
  payload
});

export const DeleteCandidate = payload => ({
  type: DELETE_CANDIDATE,
  payload
});
